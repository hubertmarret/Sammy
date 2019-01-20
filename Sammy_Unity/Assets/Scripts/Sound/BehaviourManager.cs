using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityEngine
{
    public static class AudioManager
    {

        public static void FadeOut(this AudioSource a, float duration, float minVol)
        {
            a.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(a, duration, minVol));
        }

        private static IEnumerator FadeOutCore(AudioSource a, float duration, float minVol)
        {
            float startVolume = a.volume;

            while (a.volume > minVol)
            {
                a.volume -= startVolume * Time.deltaTime / duration;
                yield return new WaitForEndOfFrame();
            }
            
        }
    }

    public static class FadingManager
    {
        public static void FadeOut(this GameObject g, float duration, string levelName)
        {
            g.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(g, duration, levelName));
        }

        private static IEnumerator FadeOutCore(GameObject g, float duration, string levelName)
        {
            Image img = g.GetComponent<Image>();
            Color thisAlpha = img.color;
            while (img.color.a < 1)
            {
                thisAlpha = img.color;
                thisAlpha.a += 0.4f * Time.deltaTime / duration ;/// TODO duration;
                img.color = thisAlpha;
                yield return new WaitForEndOfFrame();
            }
            SceneManager.LoadScene(levelName);
        }

        public static void FadeOutFadeIn(this GameObject g, float duration, GameObject imgOut, GameObject imgIn)
        {
            g.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutFadeInCore(g, duration, imgOut, imgIn));
        }

        private static IEnumerator FadeOutFadeInCore(GameObject g, float duration, GameObject imgOut, GameObject imgIn)
        {

            Image img = g.GetComponent<Image>();
            
            Color thisAlpha = img.color;
            while (img.color.a < 1)
            {
                thisAlpha = img.color;
                thisAlpha.a += 0.4f * Time.deltaTime / duration;/// TODO duration;
                img.color = thisAlpha;
                yield return new WaitForEndOfFrame();
            }
            
            imgOut.GetComponent<SpriteRenderer>().enabled = false;
            imgIn.GetComponent<SpriteRenderer>().enabled = true;

            while (img.color.a > 0.01f)
            {
                thisAlpha = img.color;
                thisAlpha.a -= 0.4f * Time.deltaTime / duration;/// TODO duration;
                img.color = thisAlpha;
                yield return new WaitForEndOfFrame();
            }
        }


        public static void FadeOutFadeIn(this GameObject g, float duration, Sprite newSprite)
        {
            g.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutFadeInCore(g, duration, newSprite));
        }

        private static IEnumerator FadeOutFadeInCore(GameObject g, float duration, Sprite newSprite)
        {

            Image img = GameObject.FindGameObjectWithTag("Fond").GetComponent<Image>();

            Color thisAlpha = img.color;
            while (img.color.a < 1)
            {
                thisAlpha = img.color;
                thisAlpha.a += 0.4f * Time.deltaTime / duration;/// TODO duration;
                img.color = thisAlpha;
                yield return new WaitForEndOfFrame();
            }

            g.GetComponent<SpriteRenderer>().sprite = newSprite;

            while (img.color.a > 0.01f)
            {
                thisAlpha = img.color;
                thisAlpha.a -= 0.4f * Time.deltaTime / duration;/// TODO duration;
                img.color = thisAlpha;
                yield return new WaitForEndOfFrame();
            }
        }

        public static void FadeIn(this GameObject g, float duration)
        {
            g.GetComponent<MonoBehaviour>().StartCoroutine(FadeInCore(g, duration));
        }

        private static IEnumerator FadeInCore(GameObject g, float duration)
        {
            Image img = g.GetComponent<Image>();
            
            Color thisAlpha = img.color;
            while (img.color.a > 0.01f) 
            {
                thisAlpha = img.color;
                thisAlpha.a -= 0.4f * Time.deltaTime / duration;/// TODO duration;
                img.color = thisAlpha;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
