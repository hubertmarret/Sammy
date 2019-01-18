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
        Destroy(startButton.gameObject);
        SceneManager.LoadScene("Scene0");
    }
}
