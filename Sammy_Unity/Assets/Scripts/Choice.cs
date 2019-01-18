using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice
{
    public int id;
    public string text;
    public string target;

    public Choice(int a_id, string a_text, string a_target)
    {
        id = a_id;
        text = a_text;
        target = a_target;
    }

    public void Print()
    {
        Debug.Log("Choice : " + text);
    }
}
