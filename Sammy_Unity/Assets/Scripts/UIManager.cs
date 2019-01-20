using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform canvas;

    public SimpleObjectPool choicePool;

    private List<ChoiceDisplay> choiceDisplays;

    void Awake()
    {
        canvas = GameObject.Find("HUDCanvas").transform;
        DontDestroyOnLoad(canvas.gameObject);

        choicePool = GameObject.Find("ChoiceObjectPool").GetComponent<SimpleObjectPool>();

        choiceDisplays = new List<ChoiceDisplay>();
    }

    public void AddChoiceGroup(List<Choice> a_choiceGroup)
    {
        foreach (Choice choice in a_choiceGroup)
        {
            AddChoiceD(choice);
        }

        switch (choiceDisplays.Count)
        {
            case 1:
                Display1Choice(choiceDisplays[0]);
                break;

            case 2:
                if(choiceDisplays[0].GetTarget() == choiceDisplays[1].GetTarget())
                {
                    Display2Choices(choiceDisplays[0], choiceDisplays[1]);
                }
                else
                {
                    Display1Choice(choiceDisplays[0]);
                    Display1Choice(choiceDisplays[1]);
                }
                break;

            case 3:
                if(choiceDisplays[0].GetTarget() == choiceDisplays[1].GetTarget() && choiceDisplays[0].GetTarget() == choiceDisplays[2].GetTarget())
                {
                    Display3Choices(choiceDisplays[0], choiceDisplays[1], choiceDisplays[2]);
                }
                else
                {
                    Display1Choice(choiceDisplays[0]);
                    Display1Choice(choiceDisplays[1]);
                    Display1Choice(choiceDisplays[2]);
                }
                break;

            default: Display1Choice(choiceDisplays[0]); break;
        }
    }

    private void AddChoiceD(Choice a_choice)
    {
        GameObject newChoiceButton = choicePool.GetObject();
        newChoiceButton.transform.SetParent(canvas);

        ChoiceDisplay choiceDisplay = newChoiceButton.GetComponent<ChoiceDisplay>();
        choiceDisplay.Setup(a_choice);
        choiceDisplays.Add(choiceDisplay);
    }

    public void RemoveChoiceGroup()
    {
        foreach (ChoiceDisplay choiceD in choiceDisplays)
        {
            choicePool.ReturnObject(choiceD.gameObject);
        }
        choiceDisplays.Clear();
    }

    private void Display1Choice(ChoiceDisplay a_choiceD)
    {
        a_choiceD.Display(new Vector3(0, 60));
    }

    private void Display2Choices(ChoiceDisplay a_choiceD1, ChoiceDisplay a_choiceD2)
    {
        a_choiceD1.Display(new Vector3(100, 60));
        a_choiceD2.Display(new Vector3(-100, 60));
    }
    private void Display3Choices(ChoiceDisplay a_choiceD1, ChoiceDisplay a_choiceD2, ChoiceDisplay a_choiceD3)
    {
        a_choiceD1.Display(new Vector3(0, 120));
        a_choiceD2.Display(new Vector3(-100, 60));
        a_choiceD3.Display(new Vector3(100, 60));
    }
}
