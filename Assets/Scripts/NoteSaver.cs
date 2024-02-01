using UnityEngine;
using System.IO;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class NoteSaver : MonoBehaviour
{
    public TextAsset csv_file;

    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;

    public void SaveNote()
    {
        File.AppendAllText(getPath() + "/Data/NotesData.csv", '\n' + input_note_name.text + ',' + input_note_text.text + ',' + input_note_image_url);
        Debug.Log("NoteSaver: данные сохранены.");
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    private static string getPath()
    {
        #if UNITY_ANDROID
            Debug.Log("NoteSaver: путь получен.");
            return Application.persistentDataPath;
        #else
            Debug.Log("NoteSaver: путь получен.");
            return Application.dataPath;
        #endif
    }
}
