using System.Collections;
using UnityEngine;
using Vuforia;
using UnityEngine.Networking;
using TMPro;
using System.IO;
using System.Text;

public class NotesLoader : MonoBehaviour
{
    public GameObject note_prefab;

    private char r = '→';
    private char f = '↔';

    private string input_note_index;
    private string input_note_name;
    private string input_note_text;
    private string input_note_image_url;

    public Texture2D note_image_file;

    private float load_counter;
    private float len;
    public TMP_Text loading_bar_text;
    public GameObject loading_bar_image;

    public string path;

    public void Awake()
    {
        StartCoroutine(ReadData());
    }

    IEnumerator ReadData()
    {
        path = getPath();

        if (File.Exists(path) == false)
        {
            using (StreamWriter head = new StreamWriter(path))
                head.Write("id↔name↔text↔image_url");
                HideLoadingBar();
        }

        StreamReader data_file = new StreamReader(getPath(), Encoding.Default);
        string[] records = data_file.ReadToEnd().Split(r);
        data_file.Close();

        len = records.Length - 1;

        for (int i = 1; i < records.Length; i++)
        {
            string[] fields = records[i].Split(f);

            input_note_index = fields[0];
            input_note_name = fields[1];
            input_note_text = fields[2];
            input_note_image_url = fields[3];

            yield return StartCoroutine(RetrieveTextureFromWeb());
        }
    }

    IEnumerator RetrieveTextureFromWeb()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(input_note_image_url))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
                Debug.Log("Link: " + input_note_image_url);
            }
            else
            {
                // Get downloaded texture once the web request completes
                var texture = DownloadHandlerTexture.GetContent(uwr);
                note_image_file = texture;
                Debug.Log("Image downloaded " + uwr);

                CreateImageTargetFromDownloadedTexture();
            }
        }
    }

    void CreateImageTargetFromDownloadedTexture()
    {
        var mTarget = VuforiaBehaviour.Instance.ObserverFactory.CreateImageTarget(
            note_image_file,
            1f,
            input_note_name);
        // add the Default Observer Event Handler to the newly created game object
        mTarget.gameObject.AddComponent<DefaultObserverEventHandler>();
        Debug.Log("Instant Image Target created " + mTarget.TargetName);

        GameObject note = GameObject.Find(input_note_name);
        Instantiate(note_prefab, note.transform);

        note.GetComponentInChildren<NoteDataBuffer>().trigger = true;
        note.GetComponentInChildren<NoteDataBuffer>().note_index = input_note_index;
        note.GetComponentInChildren<NoteDataBuffer>().note_name = input_note_name;
        note.GetComponentInChildren<NoteDataBuffer>().note_text = input_note_text;

        load_counter += 1;

        loading_bar_text.text = "Загрузка... (" + load_counter + "/" + len + ")";
        loading_bar_image.GetComponent<UnityEngine.UI.Image>().fillAmount = load_counter / len;
        
        if (load_counter >= len)
        {
            Invoke("HideLoadingBar", 0.5f);
        }
    }

    private void HideLoadingBar()
    {
        GameObject.Find("Load Notes - Panel").SetActive(false);
    }

    private static string getPath()
    {
#if UNITY_EDITOR
        return "C:/Notes-AR_Data/NotesData.txt";
#elif UNITY_ANDROID
        return Application.persistentdata;
#endif
    }
}
