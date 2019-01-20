using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenSprite : MonoBehaviour
{
    public int fitWidth = 1;
    public int fitHeight = 1;
    void Awake()
    {
        SpriteFunctions.ResizeSpriteToScreen(gameObject, Camera.main, fitWidth, fitHeight);
    }
    
}
