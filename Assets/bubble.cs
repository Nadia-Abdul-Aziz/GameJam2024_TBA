using UnityEngine;

public class PlayLegacyAnimation : MonoBehaviour
{
    public Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("BubblePop"); // Replace "BubblePop" with the clip's name if different
        }
    }
}
