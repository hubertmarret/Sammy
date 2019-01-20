using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public Button testButton;
    public Text subtitles;

    private int currentSequence;
    private List<Sequence> sequences;

    private DialogParser parser;

    private UIManager uiManager;

    private AudioPlayer audioPlayer;

    /////////////////////
    /// METHODS
    /////////////////////

    void Start()
    {
        currentSequence = 0;

        parser = new DialogParser("Assets/Resources/Dialogs.csv");

        sequences = parser.Parse();

        uiManager = GameManager.instance.uiManager;

        audioPlayer = GameObject.Find("Audio Player").GetComponent<AudioPlayer>();

        testButton = GameObject.Find("HUDCanvas").transform.Find("TestButton").gameObject.GetComponent<Button>();
        testButton.onClick.AddListener(TestButtonClicked); //test

        subtitles = GameObject.Find("HUDCanvas").transform.Find("Subtitles").gameObject.GetComponent<Text>();
    }

    public void StartScenario()
    {
        ReadSequence();
    }

    public void ReadSequence()
    {
        DialogLine line = GetCurrentLine();
        //line.Print();

        if(line.type == "choice")
        {
            List<Choice> choiceGroup = sequences[currentSequence].GetChoiceGroup(line);
            uiManager.AddChoiceGroup(choiceGroup);
        }
        else
        {
            audioPlayer.Play(line.text);
            subtitles.text = line.text;
            //ChangeLine();
        }
    }

    private void ChangeSequence(int a_nextSequence)
    {
        currentSequence = a_nextSequence;
        //Debug.Log("LOAD SCENE : " + currentSequence);
        SceneManager.LoadScene("Scene" + currentSequence);
    }

    public void ChangeLine()
    {
        int nextSequence = sequences[currentSequence].ChangeLine();

        if(nextSequence == -1)
        {
            SceneManager.LoadScene("EndScene");
        }
        else if (nextSequence != currentSequence)
        {
            ChangeSequence(nextSequence);
        }
        else
        {
            ReadSequence();
        }
    }

    public void ChangeLineFromChoice(int a_choiceClicked)
    {
        uiManager.RemoveChoiceGroup();
        subtitles.text = sequences[currentSequence].GetDialogLine(a_choiceClicked).text;
        int nextSequence = sequences[currentSequence].ChangeLine(a_choiceClicked);
        if (nextSequence != currentSequence)
        {
            ChangeSequence(nextSequence);
        }
    }

    public DialogLine GetCurrentLine()
    {
        return sequences[currentSequence].GetCurrentLine();
    }


    /////////////////////
    /// TESTS
    /////////////////////

    public void TestButtonClicked()
    {
        ReadSequence();
        //GetCurrentLine().Print();
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
