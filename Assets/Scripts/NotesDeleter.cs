using UnityEngine;
using System.IO;

public class NotesDeleter : MonoBehaviour
{
    // CSV-файл
    public TextAsset csv_file;

    public void DeleteNotes()
    {
        File.WriteAllText(getPath() + "/Data/NotesData.csv", "name,text,image_url");
        Debug.Log("Данные CSV-файла очищены.");
    }

    private static string getPath()
    {
        #if UNITY_EDITOR
            Debug.Log("Редактор: путь получен.");
            return Application.dataPath;
        #elif UNITY_ANDROID
            Debug.Log("Андроид: путь получен.");
            return Application.persistentDataPath;
        #else
            Debug.Log("???: путь получен.");
            return Application.dataPath;
        #endif
    }
}
