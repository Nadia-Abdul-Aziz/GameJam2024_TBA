using UnityEngine;
using UnityEngine.UI;

public class boing2 : MonoBehaviour
{
    [Header("Boing Settings")]
    [SerializeField] private float boingWidth = 50f;  // How far the image bounces horizontally
    [SerializeField] private float boingSpeed = 2f;   // How fast the image moves

    private RectTransform rectTransform;
    private Vector2 startPosition;

    void Start()
    {
        // Get the RectTransform thing
        rectTransform = GetComponent<RectTransform>();

        //initial position of the arrow
        startPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // calculate the new X position using a sine wave...idk how it works tbh, we love googling stuff
        float newX = startPosition.x + (Mathf.Sin(Time.time * boingSpeed) * boingWidth);

        // new position vector
        Vector2 newPosition = new Vector2(newX, startPosition.y);

        // Apply the new position
        rectTransform.anchoredPosition = newPosition;
    }
}