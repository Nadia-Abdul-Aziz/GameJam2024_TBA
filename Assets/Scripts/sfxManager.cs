using UnityEngine;
using UnityEngine.UI;

public class sfxManager : MonoBehaviour
{
    [SerializeField] Image sfxOn;
    [SerializeField] Image sfxOff; // Images
    [SerializeField] AudioSource sfx1;
    // Don't need these rn but might change my mind
    // [SerializeField] AudioSource sfx2;
    // [SerializeField] AudioSource sfx3;
    // [SerializeField] AudioSource sfx4;
    // [SerializeField] AudioSource sfx5;
    // [SerializeField] AudioSource sfx6;
    // [SerializeField] AudioSource sfx7;
    // [SerializeField] AudioSource sfx8;
    // [SerializeField] AudioSource sfx9;
    // [SerializeField] AudioSource sfx10;

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

        // Update the UI based on the mute status
        UpdateButton();

        // Set the audio source's volume based on muted status
        sfx1.mute = muted;
        // sfx2.mute = muted;
        // sfx3.mute = muted;
        // sfx4.mute = muted;
        // sfx5.mute = muted;
        // sfx6.mute = muted;
        // sfx7.mute = muted;
        // sfx8.mute = muted;
        // sfx9.mute = muted;
        // sfx10.mute = muted;
    }

    // Called when the mute/unmute button is pressed
    public void OnButtonPress()
    {
        // Toggle mute
        muted = !muted;

        // Mute or unmute the background music
        sfx1.mute = muted;
        // sfx2.mute = muted;
        // sfx3.mute = muted;
        // sfx4.mute = muted;
        // sfx5.mute = muted;
        // sfx6.mute = muted;
        // sfx7.mute = muted;
        // sfx8.mute = muted;
        // sfx9.mute = muted;
        // sfx10.mute = muted;

        // Save the current mute state
        Save();

        // Update the UI
        UpdateButton();
    }

    // Update button images based on the mute state
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
    // Load mute state from PlayerPrefs
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // Save current mute state to PlayerPrefs
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
