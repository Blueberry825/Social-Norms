using UnityEngine;

public class ChangeSliders_Script : MonoBehaviour
{
    private BackgroundMusic_Script bgm_Script;
    private Animator settingsAnimator;
    private bool isSettingsOpen;

    private void Start()
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
    }

    public void masterChange(float value) 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        settingsAnimator = GameObject.Find("Settings_Area").GetComponent<Animator>();

        if (settingsAnimator.GetBool("OptionsMenu") == true)
        {
            bgm_Script.MasterVolumeSliderChanged(value);
        }
    }

    public void bgmChange(float value) 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        settingsAnimator = GameObject.Find("Settings_Area").GetComponent<Animator>();

        if (settingsAnimator.GetBool("OptionsMenu") == true)
        {
            bgm_Script.MusicVolumeSliderChanged(value);
        }
    }

    public void sfxChange(float value) 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        settingsAnimator = GameObject.Find("Settings_Area").GetComponent<Animator>();

        if (settingsAnimator.GetBool("OptionsMenu") == true)
        {
            bgm_Script.SFXVolumeSliderChanged(value);
        }
    }

}
