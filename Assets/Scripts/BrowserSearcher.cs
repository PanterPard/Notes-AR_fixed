using UnityEngine;

public class BrowserSearcher : MonoBehaviour
{
    public TextAsset csv_file;
    public string browser;

    public void Awake()
    {
        string[] records = csv_file.text.Split('\n');
        string[] fields = records[1].Split(',');
        {
            browser = fields[0];
        }
    }

    public void SearchInBrowser()
    {
        Application.OpenURL(@browser);
    }
}
