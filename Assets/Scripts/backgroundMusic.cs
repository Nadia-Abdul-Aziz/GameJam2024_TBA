using UnityEngine;


public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic background;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (background == null)
        {
            background = this;
            DontDestroyOnLoad(background);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
