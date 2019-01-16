using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogParser
{
    private List<DialogLine> lines;
    private List<Sequence> sequences;
    private string filePath;

    public DialogParser(string a_filepath)
    {
        filePath = a_filepath;
        lines = new List<DialogLine>();
    }

    public List<DialogLine> GetDialogLines()
    {
        return lines;
    }

    public List<Sequence> Parse()
    {
        Read(filePath);

        sequences = new List<Sequence>();

        foreach(DialogLine line in lines)
        {
            if(sequences.Count <= line.sequence_id)
            {
                Sequence sequence = new Sequence(line.sequence_id);
                sequences.Add(sequence);
            }
            sequences[line.sequence_id].AddDialogLine(line);
        }

        return sequences;
    }

    private void Read(string a_filePath)
    {
        int counter = 0;

        var reader = new StreamReader(a_filePath);


        while (!reader.EndOfStream)
        {
            var stringline = reader.ReadLine();

            // don't parse first line
            if (counter != 0)
            {
                // parser
                var values = stringline.Split(';');
                DialogLine line = new DialogLine
                {
                    sequence_id = Int32.Parse(values[0]),
                    id = Int32.Parse(values[1]),
                    character = values[2],
                    text = values[3],
                    type = values[4],
                    choice_group = values[5],
                    target = values[6],
                    next = values[7]
                };
                lines.Add(line);
            }

            ++counter;
        }
    }
}
