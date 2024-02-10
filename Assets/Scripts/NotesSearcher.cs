using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class NotesSearcher : MonoBehaviour
{
    private char r = '→';
    private char f = '↔';

    public TMP_InputField output_notes;
    public string notes;

    public string file_path;

    public void Awake()
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

        for (int i = 1; i < records.Length; i++)
        {
            string[] fields = records[i].Split(f);
            {
                notes += fields[0] + ", " + fields[1] + ", " + fields[5] + '\n';
            }
        }
    }

    public void OutputData()
    {
        output_notes.text = "Индекс, имя, ошибка:\n" + notes;
    }

    private static string getPath()
    {
        return Application.persistentDataPath;
    }
}
