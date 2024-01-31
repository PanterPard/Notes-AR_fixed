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
        string[] fields = records[1].Split(',');
        {
            input_browser.text = fields[0];
        }
    }

    public void WriteSettingsData()
    {
        File.WriteAllText(getPath() + "/Data/UserSettings.csv", "browser" + '\n' + input_browser.text);
    }

    private static string getPath()
    {
        #if UNITY_EDITOR
            Debug.Log("��������: ���� �������.");
            return Application.dataPath;
        #elif UNITY_ANDROID
            Debug.Log("�������: ���� �������.");
            return Application.persistentDataPath;
        #else
            Debug.Log("???: ���� �������.");
            return Application.dataPath;
        #endif
    }
}
