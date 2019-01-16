using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public Button testButton;

    private int currentSequence;
    private List<Sequence> sequences;

    private DialogParser parser;


    /////////////////////
    /// METHODS
    /////////////////////

    void Start()
    {
        currentSequence = 0;

        parser = new DialogParser("Assets/Resources/Dialogues.csv");

        sequences = parser.Parse();

        testButton.onClick.AddListener(TestButtonClicked); //test
    }

    private void StartScenario()
    {
        ReadSequence();
    }

    private void ReadSequence()
    {
        DialogLine line = GetCurrentLine();
        line.Print();
        ChangeLine();
    }

    private void ChangeSequence(int a_nextSequence)
    {
        currentSequence = a_nextSequence;
    }

    private void ChangeLine()
    {
        int nextSequence = sequences[currentSequence].ChangeLine();
        if (nextSequence != currentSequence)
        {
            ChangeSequence(nextSequence);
        }
    }

    private DialogLine GetCurrentLine()
    {
        return sequences[currentSequence].GetCurrentLine();
    }


    /////////////////////
    /// TESTS
    /////////////////////

    public void TestButtonClicked()
    {
        ReadSequence();
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
