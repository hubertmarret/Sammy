using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceLauncher : MonoBehaviour
{
    void Start()
    {
        FadingManager.FadeIn(GameObject.FindGameObjectWithTag("Fond"), 0.5f);
        GameManager.instance.scenarioManager.ReadSequence();
    }
}
