using UnityEngine;
using UnityEngine.UI;

//Copied and pasted this from the previous button script, removed comments 
//Sound effects in the main page (all)
public class mainSFXManager : MonoBehaviour
{

    [SerializeField] Image sfxOn;
    [SerializeField] Image sfxOff;
    [SerializeField] AudioSource sfx1;
    [SerializeField] AudioSource sfx2;
    [SerializeField] AudioSource sfx3;
    [SerializeField] AudioSource sfx4;
    [SerializeField] AudioSource sfx5;
    [SerializeField] AudioSource sfx6;
    [SerializeField] AudioSource sfx7;
    [SerializeField] AudioSource sfx8;

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


        sfx1.mute = muted;
    }

    public void OnButtonPress()
    {

        muted = !muted;


        sfx1.mute = muted;
        sfx2.mute = muted;
        sfx3.mute = muted;
        sfx4.mute = muted;
        sfx5.mute = muted;
        sfx6.mute = muted;
        sfx7.mute = muted;
        sfx8.mute = muted;


        Save();


        UpdateButton();
    }


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

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }


    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
