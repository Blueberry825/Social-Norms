using UnityEngine;

public class ChangeSliders_Script : MonoBehaviour
{
    private BackgroundMusic_Script bgm_Script;

    private void Start()
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
    }

    public void masterChange(float value) 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        bgm_Script.MasterVolumeSliderChanged(value);
    }

    public void bgmChange(float value) 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        bgm_Script.MusicVolumeSliderChanged(value);
    }

    public void sfxChange(float value) 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        bgm_Script.SFXVolumeSliderChanged(value);
    }

}
