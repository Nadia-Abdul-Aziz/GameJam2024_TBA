using UnityEngine;

public class MainSoundScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] mainMusicSound = GameObject.FindGameObjectsWithTag("music");
        if (mainMusicSound.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
