using UnityEngine;
using System.IO;
using System.Text;

public class BrowserSearcher : MonoBehaviour
{
    private char r = '\n';
    private char f = ',';

    public string browser;

    public string file_path;

    public void Awake()
    {
        file_path = getPath() + "/UserSettings.txt";

        if (File.Exists(file_path) == false)
        {
            using (StreamWriter head = new StreamWriter(file_path))
                head.Write("name,value");
        }

        StreamReader data_file = new StreamReader(file_path, Encoding.UTF8);
        string[] records = data_file.ReadToEnd().Split(r);
        data_file.Close();

        string[] fields = records[1].Split(f);
        {
            browser = fields[1];
        }
    }

    public void SearchInBrowser()
    {
        Application.OpenURL(@browser);
    }

    private static string getPath()
    {
        return Application.persistentDataPath;
    }
}
