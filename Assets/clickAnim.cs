using UnityEngine;
//for IEnum later
using System.Collections;

public class clickAnim : MonoBehaviour
{
    private Animator animator; //for anim
    private SpriteRenderer spriteRenderer; //for visibility

    [SerializeField] private string animationName = "Anim"; //to plug in the animation needed to be played
    [SerializeField] private float animationDelay = 1f; // delay before hiding sprite becaus ethe animation wouldn't play otherwise

    //track if animation has been played already
    private bool hasPlayed = false;

    void Start()
    {

        animator = GetComponent<Animator>(); //finding components
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Disable the animator so it doesn't automatically play
        animator.enabled = false;
    }

    //clickety
    void OnMouseDown()
    {
        // Only play the animation if it hasn't been played yet
        if (!hasPlayed)
        {
            // Enable animation
            animator.enabled = true;

            // Play animation
            animator.Play(animationName, 0, 0f);

            // change to true so it stops
            hasPlayed = true;

            //hide sprite after delay
            //time based operator
            StartCoroutine(HideSpriteAfterDelay(animationDelay));
        }
    }

    //coroutine function that waits for a specified time before hiding bubble
    IEnumerator HideSpriteAfterDelay(float delay)
    {
        // Wait for specified time (in inspector)
        yield return new WaitForSeconds(delay);

        // Disable sprite renderer, REMOVING SPRITE!!
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }
}

