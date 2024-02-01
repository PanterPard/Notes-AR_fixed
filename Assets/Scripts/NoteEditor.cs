using UnityEngine;
using System.IO;
using TMPro;

public class NoteEditor : MonoBehaviour
{
    public TextAsset csv_file;

    public TMP_InputField input_name;
    public TMP_InputField input_text;

    public int note_index;

    public string[] records;

    public void StartEditNote()
    {
        records = csv_file.text.Split('\n');
        for (int i = 1; i < records.Length; i++)
        {
            string[] field = records[i].Split('\t');
            if (field[0] == input_name.text)
            {
                records[i] = input_name.text + '\t' + input_text.text + '\t' + field[2];
                EndEditNote();
                break;
            }
        }
    }

    private void EndEditNote()
    {
        File.WriteAllText(getPath() + "/Data/NotesData.csv", "name,text,image_url");
        for (int i = 1; i < records.Length; i++)
        {
            File.AppendAllText(getPath() + "/Data/NotesData.csv", '\n' + records[i]);
        }
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        Debug.Log("NoteEditor: данные обновлены.");
        #endif
    }

    // C:\Unity Projects\Notes-AR_fixed\Assets\Data
    private static string getPath()
    {
        #if UNITY_EDITOR
        Debug.Log("NoteEditor: путь получен.");
        return Application.dataPath;
        #elif UNITY_ANDROID
        Debug.Log("NoteEditor: путь получен.");
        return Application.persistentDataPath;
        #endif
    }
}
