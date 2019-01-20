using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteFunctions
{
    // If fitToScreenWidth is set to 1 then the width fits the screen width.
    // If it is set to anything over 1 then the sprite will not fit the screen width, it will be divided by that number.
    // If it is set to 0 then the sprite will not resize in that dimension.
    public static void ResizeSpriteToScreen(GameObject theSprite, Camera theCamera, int fitToScreenWidth, int fitToScreenHeight)
    {
        SpriteRenderer sr = theSprite.GetComponent<SpriteRenderer>();
        if (sr == null) return;

        theSprite.transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = theCamera.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        if (fitToScreenWidth == 0 && fitToScreenHeight != 0)
        {
            theSprite.transform.localScale = new Vector3(worldScreenHeight / height / fitToScreenHeight, worldScreenHeight / height / fitToScreenHeight, theSprite.transform.localScale.z);
        }

        else if (fitToScreenWidth != 0 && fitToScreenHeight == 0)
        {
            theSprite.transform.localScale = new Vector3(worldScreenWidth / width / fitToScreenWidth, worldScreenWidth / width / fitToScreenWidth, theSprite.transform.localScale.z);
        }

        else if (fitToScreenWidth != 0 && fitToScreenHeight != 0)
        {
            theSprite.transform.localScale = new Vector3(worldScreenWidth / width / fitToScreenWidth, worldScreenHeight / height / fitToScreenHeight, theSprite.transform.localScale.z);
        }
    }
}
