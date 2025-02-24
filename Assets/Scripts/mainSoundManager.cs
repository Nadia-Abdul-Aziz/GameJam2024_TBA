using UnityEngine;
using UnityEngine.UI;

//Copied and pasted this from the previous button script, removed comments
//Music in the main page
public class mainSoundManager : MonoBehaviour
{
    [SerializeField] Image musicOn; //image on
    [SerializeField] Image musicOff; //image off
    [SerializeField] AudioSource backgroundMusic; //input for the background track

    //set default to on
    private bool muted = false;

    void Start()
    {
        // if the thing is already on mute, set to default, 0 = unmuted
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            //Get previous setting from old game
            Load();
        }

        //changing the image
        UpdateButton();
        //Don't remember why i needed this again
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
