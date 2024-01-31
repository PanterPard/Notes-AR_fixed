using UnityEngine;
using System.IO;
using TMPro;

public class NotesSaver : MonoBehaviour
{
    // CSV-����
    public TextAsset csv_file;

    // ���� �����
    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;

    public void SaveNote()
    {
        File.AppendAllText(getPath() + "/Data/NotesData.csv", '\n' + input_note_name.text + ',' + input_note_text.text + ',' + input_note_image_url.text);
        Debug.Log("������ ��������� � CSV-����.");
    }

    private static string getPath()
    {
        #if UNITY_ANDROID
            Debug.Log("�������: ���� �������.");
            return Application.persistentDataPath;
        #else
            Debug.Log("��������: ���� �������.");
            return Application.dataPath;
        #endif
    }
}
