using System.Collections;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public string array = "0,1,2,3,4,5,6,7,8,9";
    public string input_number = "";

    private void Start()
    {
        StartCoroutine(Read());
    }

    IEnumerator Read()
    {
        string[] numbers = array.Split(',');
        foreach (string number in numbers)
        {
            input_number = number;
            Debug.Log(number);
            yield return StartCoroutine(Processing());
        }
    }


    IEnumerator Processing()
    {
        yield return null;

        Write();
    }

    void Write()
    {
        Debug.Log("Output: " + input_number);
    }

    
}
