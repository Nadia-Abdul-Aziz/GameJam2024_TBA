using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    public Image imageToFade;
    public float fadeDuration = 2f;
    public float delayBetweenFades = 1f;

    private void Start()
    {
        if (imageToFade == null)
        {
            imageToFade = GetComponent<Image>();
        }
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(FadeImage(1f));  // Fade in (alpha = 1)
            yield return new WaitForSeconds(delayBetweenFades);  // Wait 

            yield return StartCoroutine(FadeImage(0f));  // Fade out (alpha = 0) STARTING VALUE!!
            yield return new WaitForSeconds(delayBetweenFades);  // Wait 
        }
    }

    private IEnumerator FadeImage(float targetAlpha)
    {
        float startAlpha = imageToFade.color.a;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            imageToFade.color = new Color(imageToFade.color.r, imageToFade.color.g, imageToFade.color.b, newAlpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        imageToFade.color = new Color(imageToFade.color.r, imageToFade.color.g, imageToFade.color.b, targetAlpha);
    }
}
