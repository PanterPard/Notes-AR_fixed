using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameEdit : MonoBehaviour
{
    public Text output_name;
    public Text output_date;

    private string seconds, minutes, hours, days, months, years;

    public void OnNameEdit()
    {
        output_name.text = GetComponent<InputField>().text;

        seconds = System.DateTime.Now.Second.ToString();
        minutes = System.DateTime.Now.Minute.ToString();
        hours = System.DateTime.Now.Hour.ToString();
        days = System.DateTime.Now.Day.ToString();
        months = System.DateTime.Now.Month.ToString();
        years = System.DateTime.Now.Year.ToString();

       output_date.text = hours + ':' + minutes + ':' + seconds + '\n' + days + '.' + months + '.' + years;
    }
}
