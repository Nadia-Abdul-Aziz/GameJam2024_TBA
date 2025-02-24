using UnityEngine;
using UnityEngine.UI;

//Copied and pasted this from the previous button script, removed comments 
//Sound effects in the main page (all)
public class mainSFXManager : MonoBehaviour
{

    //all inputs in inspector
    [SerializeField] Image sfxOn; //image 1
    [SerializeField] Image sfxOff; //image 2
    [SerializeField] AudioSource sfx1; //ALL the sound effects, it's a mess so idk what is what 
    [SerializeField] AudioSource sfx2;
    [SerializeField] AudioSource sfx3;
    [SerializeField] AudioSource sfx4;
    [SerializeField] AudioSource sfx5;
    [SerializeField] AudioSource sfx6;
    [SerializeField] AudioSource sfx7;
    [SerializeField] AudioSource sfx8;
    [SerializeField] AudioSource sfx9;
    [SerializeField] AudioSource sfx10;

    //checking if mute
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
            //Get previous setting from old game!!!!!! RELOADS!!
            Load();
        }

        //changes the button image
        UpdateButton();

        //idk why this is here tbh???
        sfx1.mute = muted;
    }

    public void OnButtonPress()
    {
        //toggle status when clicked
        muted = !muted;

        //all of them
        sfx1.mute = muted;
        sfx2.mute = muted;
        sfx3.mute = muted;
        sfx4.mute = muted;
        sfx5.mute = muted;
        sfx6.mute = muted;
        sfx7.mute = muted;
        sfx8.mute = muted;
        sfx9.mute = muted;
        sfx10.mute = muted;

        //Changing image and saving for the next game!!!!
        Save();


        UpdateButton();
    }

    //changing the images based on the mute status
    private void UpdateButton()
    {
        if (muted)
        {
            sfxOn.enabled = false;
            sfxOff.enabled = true;
        }
        else
        {
            sfxOn.enabled = true;
            sfxOff.enabled = false;
        }
    }
    //SAVING & LOADING TO PLAYER PREFERENCES!!!
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }


    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
