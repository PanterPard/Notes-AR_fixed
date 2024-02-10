using UnityEngine;
using System.IO;
using TMPro;
using System.Text;
using System;

public class NoteSaver : MonoBehaviour
{
    private char r = '→';
    private char f = '↔';

    public int input_note_index = 1;
    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;
    public bool note_error;

    public string file_path;

    public void ReadData()
    {
        file_path = getPath() + "/NotesData.txt";

        if (File.Exists(file_path) == false)
        {
            using (StreamWriter head = new StreamWriter(file_path))
                head.Write("id↔name↔text↔image_url↔dateTime↔error");
        }

        StreamReader data_file = new StreamReader(file_path, Encoding.UTF8);
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
        File.AppendAllText(file_path, r + input_note_index.ToString() + f + input_note_name.text + f + input_note_text.text + f + input_note_image_url.text + f + DateTime.Now.ToString("dd/mm/yyyy hh:mm") + f + note_error.ToString());
        Debug.Log("NotesSaver: Данные сохранены.");
    }

    private static string getPath()
    {
        return Application.persistentDataPath;
    }
}
