using UnityEngine;
using UnityEngine.UI;

public class sfxManager : MonoBehaviour
{
    [SerializeField] Image sfxOn;
    [SerializeField] Image sfxOff; // Image for music OFF button
    [SerializeField] AudioSource sfx1; // Reference to the background music AudioSource

    private bool muted = false;

    void Start()
    {
        // If the muted preference doesn't exist, create it
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        // Update the UI based on the mute status
        UpdateButton();

        // Set the audio source's volume based on muted status
        sfx1.mute = muted;
    }

    // Called when the mute/unmute button is pressed
    public void OnButtonPress()
    {
        // Toggle the mute status
        muted = !muted;

        // Mute or unmute the background music
        sfx1.mute = muted;

        // Save the current mute state
        Save();

        // Update the UI
        UpdateButton();
    }

    // Update the button images based on the mute state
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
    // Load the mute state from PlayerPrefs
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // Save the current mute state to PlayerPrefs
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
