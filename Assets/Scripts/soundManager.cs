using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image musicOn;
    [SerializeField] Image musicOff;
    [SerializeField] AudioSource backgroundMusic;

    private bool muted = false; //track if muted, default is music on

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted")) //no saved preference
        {
            PlayerPrefs.SetInt("muted", 0); //default setting unmuted
            Load(); //load default
        }
        else
        {
            Load(); //load from previous game if it exists
        }


        UpdateButton(); //change ui 
        backgroundMusic.mute = muted; //apply loaded
    }

    public void OnButtonPress()
    {

        muted = !muted; //toggle mute on click

        backgroundMusic.mute = muted; //apply new state

        Save(); //self explanatory

        UpdateButton(); //image
    }

    private void UpdateButton() //change images based on state
    {
        if (muted) //change to off icon
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

    private void Load() //load whatever state is saved from the previous game
    {
        muted = PlayerPrefs.GetInt("muted") == 1; // convert int to bool, 1 = true
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0); //convert bool to int
    }
}
