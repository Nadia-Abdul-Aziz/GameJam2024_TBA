using UnityEngine;
using System.Collections;

public class clickAnim : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private string animationName = "Anim";
    [SerializeField] private float animationDelay = 1f; // delay before hiding sprite becaus ethe animation wouldn't play otherwise

    //track if animation has been played already
    private bool hasPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Disable the animator so it doesn't automatically play
        animator.enabled = false;
    }

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
            StartCoroutine(HideSpriteAfterDelay(animationDelay));
        }
    }

    IEnumerator HideSpriteAfterDelay(float delay)
    {
        // Wait
        yield return new WaitForSeconds(delay);

        // Disable sprite renderer, REMOVING SPRITE!!
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }
}

