using UnityEngine;
using System.IO;

public class NotesDeleter : MonoBehaviour
{
    public string file_path;

    public void DeleteNotes()
    {
        file_path = getPath() + "/NotesData.txt";
        File.WriteAllText(file_path, "id↔name↔text↔image_url↔dateTime↔error");
        Debug.Log("NotesDeleter: Данные очищены.");
    }

    private static string getPath()
    {
        return Application.persistentDataPath;
    }
}
