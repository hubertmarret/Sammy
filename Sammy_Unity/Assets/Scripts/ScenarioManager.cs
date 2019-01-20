using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public Button testButton;
    public Button skipButton;
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

        skipButton = GameObject.Find("HUDCanvas").transform.Find("SkipButton").gameObject.GetComponent<Button>();
        skipButton.onClick.AddListener(SkipButtonClicked); //test

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
            skipButton.gameObject.SetActive(true);
            subtitles.text = line.text;
            //ChangeLine();
        }
    }

    private void ChangeSequence(int a_nextSequence)
    {
        currentSequence = a_nextSequence;
        //SceneManager.LoadScene("Scene" + currentSequence);
        FadingManager.FadeOut(GameObject.FindGameObjectWithTag("Fond"), 0.5f, "Scene" + currentSequence);
    }

    public void ChangeLine()
    {
        skipButton.gameObject.SetActive(false);

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
        else
        {
            ReadSequence();
        }
    }

    public DialogLine GetCurrentLine()
    {
        return sequences[currentSequence].GetCurrentLine();
    }


    /////////////////////
    /// TESTS
    /////////////////////

    public void SkipButtonClicked()
    {
        if(audioPlayer.Stop())
        {
            skipButton.gameObject.SetActive(false);
            ChangeLine();
        }
    }

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
