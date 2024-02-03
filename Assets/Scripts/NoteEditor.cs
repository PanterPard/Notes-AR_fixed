using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class NoteEditor : MonoBehaviour
{
    private char r = '→';
    private char f = '↔';

    public TMP_Text input_index;
    public TMP_InputField input_name;
    public TMP_InputField input_text;

    public int note_index;

    public string[] records;

    public void StartEditNote()
    {
        string[] records = GetCSV().Split(r);
        for (int i = 1; i < records.Length; i++)
        {
            string[] field = records[i].Split(f);
            if (field[0] == input_index.text)
            {
                records[i] = field[0] + f + input_name.text + f + input_text.text + f + field[3];
                Debug.Log("NoteEditor: Вызывается EndEditNote()");
                EndEditNote();
                break;
            }
        }
    }

    private static string GetCSV()
    {
        var csv_file = Resources.Load<TextAsset>("UserData/NotesData");
        return csv_file.text;
    }

    private void EndEditNote()
    {
        File.WriteAllText(getPath(), "id↔name↔text↔image_url");
        for (int i = 1; i < records.Length; i++)
        {
            File.AppendAllText(getPath(), r + records[i]);
        }
        Debug.Log("NoteEditor: данные изменены.");
    }

    private static string getPath()
    {
        FileInfo info = new FileInfo(Path.GetFullPath("Assets/Resources/NotesData.csv"));
        Debug.Log("NoteEditor: " + info.FullName);
        return info.FullName;
    }
}
