using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicClass : MonoBehaviour {

    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public AudioSource GetAudioSource()
    {
        return _audioSource;
    }

    public void FadeOutTo(float minVol, float secondsToFade, Image panel)
    {
        float startVolume = _audioSource.volume;

        while (_audioSource.volume > minVol)
        {
            _audioSource.volume -= startVolume * Time.deltaTime / secondsToFade;
            Color thisAlpha = panel.color;
            thisAlpha.a += thisAlpha.a * Time.deltaTime / secondsToFade; ;
            panel.color = thisAlpha;
        }
 
    }

    public void FadeInTo(float maxVol, float secondsToFade, Image panel)
    {
        float startVolume = _audioSource.volume;

        while (_audioSource.volume < maxVol)
        {
            _audioSource.volume -= startVolume * Time.deltaTime / secondsToFade;
            Color thisAlpha = panel.color;
            thisAlpha.a -= thisAlpha.a * Time.deltaTime / secondsToFade; ;
            panel.color = thisAlpha;
        }

    }

}


