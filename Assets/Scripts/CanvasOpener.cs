using UnityEngine;

public class CanvasOpener : MonoBehaviour
{
    public GameObject Canvas;
    private RectTransform rectTransform;

    // declaring variables for both positions
    private Vector2 initialPosition;
    private Vector2 targetPosition;

    //storing the initial position so it knows which one to start on
    private bool isAtInitialPosition = true;

    void Start()
    {
        // applying recttransform
        rectTransform = GetComponent<RectTransform>();

        // storing the initial poasition of the button
        initialPosition = new Vector2(-390f, 211f);

        // the position it will jump to when clicked
        targetPosition = new Vector2(-180f, 211f);
    }

    public void canvasOpen()
    {
        if (Canvas != null)
        {
            // old toggle canvas mech
            bool isActive = Canvas.activeSelf;
            Canvas.SetActive(!isActive);

            // Switch position
            if (isAtInitialPosition)
            {
                rectTransform.anchoredPosition = targetPosition;
            }
            else
            {
                rectTransform.anchoredPosition = initialPosition;
            }

            // Toggle position state
            isAtInitialPosition = !isAtInitialPosition;
        }
    }
}


//Old code i'm lugging around for no reason????? It doesn't work on its own

// using UnityEngine;

// public class CanvasOpener : MonoBehaviour
// {
//     public GameObject Canvas;
//     public Vector2 position1 = new Vector2(-390, 211);
//     public Vector2 position2 = new Vector2(-180, 211);
//     private bool isAtPosition1 = true;

//     public void canvasOpen()
//     {
//         //Old canvas in-out mech
//         if (Canvas != null)
//         {
//             bool isActive = Canvas.activeSelf;
//             Canvas.SetActive(!isActive);
//         }

//         // New position switching
//         if (isAtPosition1)
//         {
//             transform.position = position2;
//         }
//         else
//         {
//             transform.position = position1;
//         }
//         isAtPosition1 = !isAtPosition1;
//     }
// }