using UnityEngine;
using System.IO;
using TMPro;
using System.Text;
using System;
using UnityEngine.Profiling;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

public class NoteDeleter : MonoBehaviour
{
    private char r = '→';
    private char f = '↔';

    public TMP_InputField input_index;

    public string[] records;
    public List<string> notes;
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
        records = data_file.ReadToEnd().Split(r);
        data_file.Close();

        notes = records.ToList();
        notes.RemoveAt(int.Parse(input_index.text));

        DeleteNote();
    }

    private void DeleteNote()
    {
        File.WriteAllText(file_path, "id↔name↔text↔image_url↔dateTime↔error" + string.Join(r, notes));
        Debug.Log("NoteDeleter: Заметка удалена.");
    }

    private static string getPath()
    {
        return Application.persistentDataPath;
    }
}
