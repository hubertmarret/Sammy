using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLine
{
    public int id;
    public int sequence_id;
    public string character;
    public string text;
    public string type;
    public string choice_group;
    public string target;
    public string next;

    public void Print()
    {
        Debug.Log("Dialog Line : " + id + "; " + sequence_id + "; " + character + "; " + text + "; " + type + "; " + choice_group + "; " + target + "; " + next);
    }
}
