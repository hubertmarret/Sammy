using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public float secondsToDelay = 5.0f;

    public Sprite spriteToLoad;

    void Start()
    {
        StartCoroutine(ChangeSpriteCoroutine(secondsToDelay));
    }

    IEnumerator ChangeSpriteCoroutine(float a_seconds)
    {
        yield return new WaitForSeconds(a_seconds);
        GetComponent<SpriteRenderer>().sprite = spriteToLoad;
    }
}
