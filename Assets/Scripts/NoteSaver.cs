using UnityEngine;
using System.IO;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class NoteSaver : MonoBehaviour
{
    public TextAsset csv_file;
    private char r = '→';
    private char f = '↔';

    public TMP_InputField input_note_name;
    public TMP_InputField input_note_text;
    public TMP_InputField input_note_image_url;

    public void SaveNote()
    {
        File.AppendAllText(getPath(), r + input_note_name.text + f + input_note_text.text + f + input_note_image_url);
        Debug.Log("NotesSaver: Данные сохранены.");
    }

    private static string getPath()
    {
        FileInfo info = new FileInfo(Path.GetFullPath("Assets/Data/NotesData.csv"));
        Debug.Log("NoteEditor: " + info.FullName);
        return info.FullName;
    }
}
