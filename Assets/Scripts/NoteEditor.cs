using UnityEngine;
using System.IO;
using TMPro;
using System.Text;

public class NoteEditor : MonoBehaviour
{
    private char r = '→';
    private char f = '↔';

    public TextAsset data_file;
    public TMP_Text input_index;
    public TMP_InputField input_name;
    public TMP_InputField input_text;

    public int note_index;

    public string[] records;

    public void StartEditNote()
    {
        StreamReader data_file = new StreamReader(getPath(), Encoding.Default);
        records = data_file.ReadToEnd().Split(r);
        data_file.Close();

        for (int i = 1; i < records.Length; i++)
        {
            string[] field = records[i].Split(f);
            if (field[0] == input_index.text)
            {
                records[i] = field[0] + f + input_name.text + f + input_text.text + f + field[3];
                EndEditNote();
                break;
            }
        }
    }

    private void EndEditNote()
    {
        File.WriteAllText(getPath(), string.Join(r, records));
        Debug.Log("NoteEditor: данные изменены.");
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
