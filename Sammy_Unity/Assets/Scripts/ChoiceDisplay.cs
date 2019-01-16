using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDisplay : MonoBehaviour
{
    public GameObject target;
    public Vector3 targetOffset1;
    public Vector3 targetOffset2;
    public Vector3 targetOffset3;

    private Button button;
    private Text label;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChoiceClicked);

        label = GetComponentInChildren<Text>();

        targetOffset1 = new Vector3(100, 80);
        targetOffset2 = new Vector3(-100, 80);
        targetOffset3 = new Vector3(0, 140);
    }

    public void Setup(Choice choice, int i)
    {
        label.text = choice.text;
        target = GameObject.Find(choice.target);

        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 targetScreenPos = camera.WorldToScreenPoint(target.transform.position);
        if(i == 0)
        {
            button.gameObject.transform.position = targetScreenPos + targetOffset1;
        }
        else if (i == 1)
        {
            button.gameObject.transform.position = targetScreenPos + targetOffset2;
        }
        else if (i == 2)
        {
            button.gameObject.transform.position = targetScreenPos + targetOffset3;
        }
    }

    public void ChoiceClicked()
    {
        Debug.Log("Choice Clicked");
    }

    public void OnMouseOver()
    {
        Debug.Log("Choice Overed");
    }
}
