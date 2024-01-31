using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class NoteDataBuffer : MonoBehaviour
{
    // Поля вывода
    public Text output_note_name;
    public Text output_note_text;

    // Данные
    public string note_name;
    public string note_text;

    // Триггер
    public bool trigger = false;

    private void FixedUpdate()
    {
        if (trigger)
        {
            output_note_name.text = note_name;
            output_note_text.text = note_text;

            Destroy(this.GetComponent<NoteDataBuffer>());
        }
    }
}
