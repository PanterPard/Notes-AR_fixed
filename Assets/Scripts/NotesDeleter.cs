using UnityEngine;
using System.IO;

public class NotesDeleter : MonoBehaviour
{
    // CSV-файл
    public TextAsset csv_file;

    public void DeleteNotes()
    {
        File.WriteAllText(getPath() + "/Data/NotesData.csv", "id↔name↔text↔image_url");
        Debug.Log("NotesDeleter: Данные очищены.");
    }

    private static string getPath()
    {
        #if UNITY_EDITOR
        return Application.dataPath;
        #else
        return Application.persistentDataPath;
        #endif
    }
}
