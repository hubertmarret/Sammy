using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

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

    public DialogLine GetCurrentLine()
    {
        return lines[currentLine];
    }

    public List<Choice> GetChoiceGroup(DialogLine a_line)
    {
        List<Choice> choiceGroup = new List<Choice>();
        DialogLine line = a_line;

        do
        {
            choiceGroup.Add(new Choice(line.id, line.text, line.target));
            line = lines[line.id + 1];
        } while (line.type == "choice" && line.choice_group == a_line.choice_group) ;

        return choiceGroup;
    }

    // return the next scenario id
    public int ChangeLine()
    {
        string nextline = lines[currentLine].next;
        if (nextline == "none")
        {
            return -1;
        }

        var next = nextline.Split('.');
        int nextScenario = Int32.Parse(next[0]);
        int nextLine = Int32.Parse(next[1]);

        if(nextScenario == id)
        {
            currentLine = nextLine;
        }
        else
        {
            currentLine = 0;
        }
        return nextScenario;
    }

    public int ChangeLine(int a_choiceClicked)
    {
        var next = lines[a_choiceClicked].next.Split('.');
        int nextScenario = Int32.Parse(next[0]);
        int nextLine = Int32.Parse(next[1]);

        if (nextScenario == id)
        {
            currentLine = nextLine;
        }
        else
        {
            currentLine = 0;
        }
        return nextScenario;
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