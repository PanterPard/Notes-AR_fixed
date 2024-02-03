using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public TextAsset csv_file;

    public TMP_InputField input_browser;

    public void Awake()
    {
        string[] records = csv_file.text.Split('\n');
        string[] fields = records[1].Split('\t');
        {
            input_browser.text = fields[0];
        }
    }

    public void WriteSettingsData()
    {
        File.WriteAllText(getPath(), "browser" + '\n' + input_browser.text);
        Debug.Log("SettingsManager: Настройки изменены.");
    }

    private static string getPath()
    {
        FileInfo info = new FileInfo(Path.GetFullPath("Assets/Data/UserSettings"));
        Debug.Log("SettingsManager: " + info.FullName);
        return info.FullName;
    }
}
