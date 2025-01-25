using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    public Image imageToFade;  // Reference to the Image component
    public float fadeDuration = 2f;  // Duration of the fade
    public float delayBetweenFades = 1f;  // Delay between fade in and fade out

    private void Start()
    {
        if (imageToFade == null)
        {
            imageToFade = GetComponent<Image>();  // Assign the Image component if not set
        }
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(FadeImage(1f));  // Fade in (alpha = 1)
            yield return new WaitForSeconds(delayBetweenFades);  // Wait for a moment

            yield return StartCoroutine(FadeImage(0f));  // Fade out (alpha = 0)
            yield return new WaitForSeconds(delayBetweenFades);  // Wait for a moment
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

        // Ensure the final alpha is exactly the target alpha
        imageToFade.color = new Color(imageToFade.color.r, imageToFade.color.g, imageToFade.color.b, targetAlpha);
    }
}
