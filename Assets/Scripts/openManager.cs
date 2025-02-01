using UnityEngine;
using UnityEngine.UI;

public class openManager : MonoBehaviour

{
    [SerializeField] Image firstImage;   // First image to switch between
    [SerializeField] Image secondImage;  // Second image to switch between

    private bool isFirstImageActive = true;

    void Start()
    {
        // Set initial state
        UpdateImages();
    }

    public void OnButtonPress()
    {
        // Toggle the state
        isFirstImageActive = !isFirstImageActive;

        // Update the images
        UpdateImages();
    }

    private void UpdateImages()
    {
        firstImage.enabled = isFirstImageActive;
        secondImage.enabled = !isFirstImageActive;
    }
}
