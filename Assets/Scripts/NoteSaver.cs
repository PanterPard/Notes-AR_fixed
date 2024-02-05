using UnityEngine;
using System.IO;
using TMPro;
using System.Text;
using System.Drawing.Text;
using JetBrains.Annotations;

public class NoteSaver : MonoBehaviour
{
    public TextAsset csv_file;
    private char r = '→';
    private char f = '↔';

    public int input_note_index = 1;
    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;

    public string path;

    public void ReadData()
    {
        path = getPath();

        if (File.Exists(path) == false)
        {
            using (StreamWriter head = new StreamWriter(path))
                head.Write("id↔name↔text↔image_url");
        }

        StreamReader data_file = new StreamReader(path, Encoding.Default);
        string[] records = data_file.ReadToEnd().Split(r);
        data_file.Close();

        for (int i = records.Length - 1; i < records.Length; i++)
        {
            string[] fields = records[i].Split(f);
            {
                if (records.Length <= 1)
                {
                    input_note_index = 1;
                }
                else
                {
                    input_note_index = int.Parse(fields[0]) + 1;
                }
                SaveNote();
            }
        }
    }

    public void SaveNote()
    {
        File.AppendAllText(path, r + input_note_index.ToString() + f + input_note_name.text + f + input_note_text.text + f + input_note_image_url.text);
        Debug.Log("NotesSaver: Данные сохранены.");
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
