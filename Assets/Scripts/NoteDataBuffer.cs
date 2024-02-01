using UnityEngine;
using TMPro;

public class NoteDataBuffer : MonoBehaviour
{
    public TMP_InputField output_note_name;
    public TMP_InputField output_note_text;

    public string note_name;
    public string note_text;

    public bool trigger = false;

    private void FixedUpdate()
    {
        if (trigger)
        {
            output_note_name.text = note_name;
            output_note_text.text = note_text;
            trigger = false;
        }
    }
}
