using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private int choiceID;
    private Text label;
    private GameObject target;
    private Button button;
    private Vector3 originalScale;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChoiceClicked);

        label = GetComponentInChildren<Text>();

        originalScale = button.gameObject.transform.localScale;
}

    public void Setup(Choice a_choice)
    {
        choiceID = a_choice.id;
        label.text = a_choice.text;
        target = GameObject.Find(a_choice.target);
    }

    public void Display(Vector3 a_targetOffset)
    {
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        button.gameObject.transform.position = targetScreenPos + a_targetOffset;
    }

    public void ChoiceClicked()
    {
        GameManager.instance.scenarioManager.ChangeLineFromChoice(choiceID);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.gameObject.transform.localScale *= 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.gameObject.transform.localScale = originalScale;
    }
}
