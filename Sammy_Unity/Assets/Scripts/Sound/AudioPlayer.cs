using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public bool dialogPlayed;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        dialogPlayed = false;
    }

    IEnumerator PlayWithDelay(float a_seconds)
    {
        yield return new WaitForSeconds(a_seconds);
        audioSource.Play();
        dialogPlayed = true;
    }

    public void Play(string a_audio)
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/" + a_audio);
        Debug.Log(audioSource.clip);
        StartCoroutine(PlayWithDelay(1f));
    }

    void Update()
    {
        if (!audioSource.isPlaying && dialogPlayed)
        {
            dialogPlayed = false;
            GameManager.instance.scenarioManager.ChangeLine();
        }
    }
}
