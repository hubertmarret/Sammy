using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice", menuName = "Choice")]
public class Choice : ScriptableObject
{
    public string text;
    public string target;

    public void Print()
    {
        Debug.Log("Choice : " + text);
    }
}
