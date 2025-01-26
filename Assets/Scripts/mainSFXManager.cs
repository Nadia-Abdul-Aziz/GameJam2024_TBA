using UnityEngine;
using UnityEngine.UI;

//Copied and pasted this from the previous button script, removed comments 
//Sound effects in the main page (all)
public class mainSFXManager : MonoBehaviour
{

    [SerializeField] Image sfxOn;
    [SerializeField] Image sfxOff;
    [SerializeField] AudioSource sfx1;

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
