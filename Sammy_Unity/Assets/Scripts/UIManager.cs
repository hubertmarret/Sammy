using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Choice choice1;
    public Choice choice2;
    public Choice choice3;

    public Transform canvas;

    public List<Choice> choices;

    public SimpleObjectPool choicePool;

    // Start is called before the first frame update
    void Start()
    {
        //choices = new List<Choice>();
        //choices.Add(choice1);
        //choices.Add(choice2);
        //choices.Add(choice3);

        //for (int i = 0; i < choices.Count; ++i)
        //{
        //    AddChoice(choices[i], i);
        //}
    }

    public void AddChoice(Choice choice, int i)
    {
        GameObject newChoice = choicePool.GetObject();
        newChoice.transform.SetParent(canvas);

        ChoiceDisplay choiceDisplay = newChoice.GetComponent<ChoiceDisplay>();
        choiceDisplay.Setup(choice, i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
