using UnityEngine;
using System.IO;
using TMPro;

public class NotesSaver : MonoBehaviour
{
    // CSV-файл
    public TextAsset csv_file;

    // Поля ввода
    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;

    public void SaveNote()
    {
        File.AppendAllText(getPath() + "/Data/NotesData.csv", '\n' + input_note_name.text + ',' + input_note_text.text + ',' + input_note_image_url.text);
        Debug.Log("Данные сохранены в CSV-файл.");
    }

    private static string getPath()
    {
        #if UNITY_ANDROID
            Debug.Log("Андроид: путь получен.");
            return Application.persistentDataPath;
        #else
            Debug.Log("Редактор: путь получен.");
            return Application.dataPath;
        #endif
    }
}
