using UnityEngine;
using UnityEngine.UI;

//Copied and pasted this from the previous button script, removed comments
//Music in the main page
public class mainSoundManager : MonoBehaviour
{
    [SerializeField] Image musicOn;
    [SerializeField] Image musicOff;
    [SerializeField] AudioSource backgroundMusic;

    private bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButton();

        backgroundMusic.mute = muted;
    }

    public void OnButtonPress()
    {
        muted = !muted;

        backgroundMusic.mute = muted;

        Save();

        UpdateButton();
    }

    private void UpdateButton()
    {
        if (muted)
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
        else
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
