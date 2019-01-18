using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    private SpriteRenderer spriteR;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();

        originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        transform.localScale *= 1.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

    private void OnMouseUp()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
