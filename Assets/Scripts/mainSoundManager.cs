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

    //Toggle status on click
    public void OnButtonPress()
    {

        muted = !muted; //toggle

        backgroundMusic.mute = muted; //Apply the new mute state to the source


        //Same thing, saving the state to player preferences
        Save();
        //change ui
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (muted) //if mute hide on icon
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
        else //opposite
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
        }
    }

    private void Load() //loading saved preference
    {
        muted = PlayerPrefs.GetInt("muted") == 1; //convert into to bool
    }

    private void Save() //self explanatory
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0); // Convert bool to int (1 if true, 0 if false) and save
    }
}
