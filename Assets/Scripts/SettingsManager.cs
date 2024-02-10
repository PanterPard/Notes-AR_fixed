using UnityEngine;
using System.IO;
using TMPro;
using System.Text;

public class SettingsManager : MonoBehaviour
{
    private char r = '\n';
    private char f = ',';

    public TMP_InputField input_browser;

    public string file_path;

    private void Awake()
    {
        ReadData();
    }

    public void ReadData()
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

        for (int i = 1; i < records.Length; i++)
        {
            string[] fields = records[i].Split(f);
            {
                if (i == 1)
                {
                    input_browser.text = fields[1];
                }
            }
        }
    }

    public void WriteSettingsData()
    {
        File.WriteAllText(file_path, "name,value\nbrowser" + f + input_browser.text);
        Debug.Log("SettingsManager: Настройки изменены.");
    }

    private static string getPath()
    {
        return Application.persistentDataPath;
    }
}
