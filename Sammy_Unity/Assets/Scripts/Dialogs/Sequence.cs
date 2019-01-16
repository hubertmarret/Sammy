using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Sequence
{
    private int id;
    private int currentLine;
    private List<DialogLine> lines;

    public Sequence(int a_id)
    {
        id = a_id;
        currentLine = 0;
        lines = new List<DialogLine>();
    }

    public void AddDialogLine(DialogLine a_line)
    {
        lines.Add(a_line);
    }

    public DialogLine GetDialogLine(int a_id)
    {
        return lines[a_id];
    }

    public void Print()
    {
        Debug.Log("Sequence : " + id);
        foreach(DialogLine line in lines)
        {
            line.Print();
        }
    }
}