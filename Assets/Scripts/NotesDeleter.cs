using UnityEngine;
using System.IO;

public class NotesDeleter : MonoBehaviour
{
    // CSV-����
    public TextAsset csv_file;

    public void DeleteNotes()
    {
        File.WriteAllText(getPath() + "/Data/NotesData.csv", "name,text,image_url");
        Debug.Log("������ CSV-����� �������.");
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
