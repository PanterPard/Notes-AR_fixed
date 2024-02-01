using UnityEngine;
using TMPro;

public class TestInputField : MonoBehaviour
{
    public TMP_InputField input_text;

    void Start()
    {
        input_text.text = "Text";
    }
}
