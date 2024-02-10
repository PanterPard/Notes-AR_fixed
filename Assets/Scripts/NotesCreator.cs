using System.Collections;
using UnityEngine;
using TMPro;
using Vuforia;
using UnityEngine.Networking;
using System;

public class NotesCreator : MonoBehaviour
{
    public GameObject note_prefab;
    public GameObject createNote_panel;
    public GameObject buttons;

    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;
    public bool note_error = false;

    public Texture2D note_image_file;

    public void CreateNote()
    {
        StartCoroutine(RetrieveTextureFromWeb());
    }

    IEnumerator RetrieveTextureFromWeb()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(input_note_image_url.text))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                note_error = true;
                Debug.Log(uwr.error);
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
            input_note_name.text);
        // add the Default Observer Event Handler to the newly created game object
        mTarget.gameObject.AddComponent<DefaultObserverEventHandler>();
        Debug.Log("Instant Image Target created " + mTarget.TargetName);

        GameObject note = GameObject.Find(input_note_name.text);
        Instantiate(note_prefab, note.transform);

        note.GetComponentInChildren<NoteDataBuffer>().trigger = true;
        note.GetComponentInChildren<NoteDataBuffer>().note_name = input_note_name.text;
        note.GetComponentInChildren<NoteDataBuffer>().note_text = input_note_text.text;
        note.GetComponentInChildren<NoteDataBuffer>().dateTime = DateTime.Now.ToString("dd/mm/yyyy hh:mm");

        this.GetComponent<NoteSaver>().note_error = note_error;
        this.GetComponent<NoteSaver>().ReadData();

        createNote_panel.SetActive(false);
        buttons.SetActive(true);
    }
}
