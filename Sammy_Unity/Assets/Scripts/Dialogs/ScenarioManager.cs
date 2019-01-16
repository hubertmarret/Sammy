using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    private int currentSequence;
    private List<Sequence> sequences;

    private DialogParser parser;

    void Start()
    {
        currentSequence = 0;

        parser = new DialogParser("Assets/Resources/Dialogues.csv");

        sequences = parser.Parse();

        //PrintScenario();
    }

    public void PrintScenario()
    {
        Debug.Log("SCENARIO");
        foreach (Sequence sequence in sequences)
        {
            sequence.Print();
        }
    }
}
