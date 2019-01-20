using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameManager gameManager;
    public Button startButton; 

    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
    }

    void Start()
    {
        startButton.onClick.AddListener(StartClicked);
    }

    private void StartClicked()
    {
        FadingManager.FadeOut(GameObject.FindGameObjectWithTag("Fond"), 0.5f, "Scene0");
        AudioSource src = GameObject.FindGameObjectWithTag("Theme").GetComponent<MusicClass>().GetAudioSource();
        AudioManager.FadeOut(src, 2.0f, 0.20f);
        //SceneManager.LoadScene("Scene0");
    }
}
