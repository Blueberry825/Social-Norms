using FMOD;
using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance backgroundMusic_Instance;

    [SerializeField] private TextMeshProUGUI MasterVolume_Number;
    [SerializeField] private TextMeshProUGUI MusicVolume_Number;
    [SerializeField] private TextMeshProUGUI SFXVolume_Number;
    private int masterTXTNumber;
    private int musicTXTNumber;
    private int sfxTXTNumber;

    [SerializeField] private GameObject masterVolume_icon;
    [SerializeField] private GameObject sfxVolume_icon;
    [SerializeField] private GameObject musicVolume_icon;
    private Animator msV_anim;
    private Animator musicV_anim;
    private Animator sfxV_anim;

    private bool pauseBool = false;
    private int pauseValue = 0;

    private DateRandomiser_Script dateRandomiser_Script;
    private GameObject alienOnScreen_;

    #region Background music parameter Numbers
    private int title_Music = 0;
    private int purpleAlien_Music = 1;
    private int greenAlien_Music = 2;
    private int orangeAlien_Music = 3;
    private int queenAlien_Music = 4;
    #endregion


    #region Busses
    FMOD.Studio.Bus Master_Bus;
    private float Master_Volume = 1.0f;
    FMOD.Studio.Bus Music_Bus;
    private float Music_Volume = 1.0f;
    FMOD.Studio.Bus SFX_Bus;
    private float SFX_Volume = 1.0f;
    #endregion

    private void Start()
    {
        backgroundMusic_Instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BackgroundMusic_Music");
        Master_Bus = Music_Bus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus");
        Music_Bus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus/BackgroundMusic_Bus");
        SFX_Bus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus/SFX_Bus");

        msV_anim = masterVolume_icon.GetComponent<Animator>();
        musicV_anim = musicVolume_icon.GetComponent<Animator>();
        sfxV_anim = sfxVolume_icon.GetComponent<Animator>();


        StartBackgroundMusic();
        SetTo_Title_Music();
    }

    public void MasterVolumeSliderChanged(float newMasterVolume) 
    {
        Master_Volume = newMasterVolume;
        Master_Bus.setVolume(Master_Volume);
        masterTXTNumber = Mathf.RoundToInt(Master_Volume * 10);
        MasterVolume_Number.text = masterTXTNumber.ToString("F0");

        msV_anim.SetInteger("Volume", masterTXTNumber);
    }

    public void MusicVolumeSliderChanged(float newMuiscVolume)
    {
        Music_Volume = newMuiscVolume;
        Music_Bus.setVolume(Music_Volume);
        musicTXTNumber = Mathf.RoundToInt(Music_Volume * 10);
        MusicVolume_Number.text = musicTXTNumber.ToString("F0");

        musicV_anim.SetInteger("Volume", musicTXTNumber);
    }

    public void SFXVolumeSliderChanged(float newSFXVolume)
    {
        SFX_Volume = newSFXVolume;
        SFX_Bus.setVolume(SFX_Volume);
        sfxTXTNumber = Mathf.RoundToInt(SFX_Volume * 10);
        SFXVolume_Number.text = sfxTXTNumber.ToString("F0");

        sfxV_anim.SetInteger("Volume", sfxTXTNumber);
    }




    public bool IsPlaying(FMOD.Studio.EventInstance instance) //checks if already playing
    {
        FMOD.Studio.PLAYBACK_STATE currentMusicState;
        instance.getPlaybackState(out currentMusicState);
        return currentMusicState != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

    #region Start/Stop Music
    public void StartBackgroundMusic() 
    {
        if (IsPlaying(backgroundMusic_Instance) == false) 
        {
            backgroundMusic_Instance.start();
        }
    }
    

    public void PauseMenuBackgroundMusic() 
    {
        pauseBool = !pauseBool;

        if (pauseBool == false) 
        { 
            pauseValue = 0;
        }
        else if (pauseBool == true) 
        {
            pauseValue = 1;
        }

        backgroundMusic_Instance.setParameterByName("IsGamePaused", pauseValue);
    }
    #endregion

    public void SceneChanged_AudioCheck(string sceneName) 
    {
        if (sceneName == "Date_Scene") 
        {
            dateRandomiser_Script = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
            alienOnScreen_ = dateRandomiser_Script.alienOnScreen;
            string alienColour_ = alienOnScreen_.GetComponent<AliensDated_Script>().alienColour;

            switch (alienColour_) 
            {
                case "Purple":
                    SetTo_PurpleAlien_Music();
                    break;
                case "Green":
                    SetTo_GreenAlien_Music();
                    break;
                case "Orange":
                    SetTo_OrangeAlien_Music();
                    break;
            }
        }

        if (sceneName == "Title_Scene" || sceneName == "Opening_Scene") 
        { 
            SetTo_Title_Music();
        }
    }

    #region Setting Background Music
    public void SetTo_PurpleAlien_Music() 
    {
        //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BackgroundMusic_Param", purpleAlien_Music);

        backgroundMusic_Instance.setParameterByName("BackgroundMusic_Param", purpleAlien_Music);
        UnityEngine.Debug.Log("changing to purple music");
    }
    public void SetTo_GreenAlien_Music() 
    {
        backgroundMusic_Instance.setParameterByName("BackgroundMusic_Param", greenAlien_Music);
        UnityEngine.Debug.Log("changing to green music");
    }
    public void SetTo_OrangeAlien_Music() 
    {
        backgroundMusic_Instance.setParameterByName("BackgroundMusic_Param", orangeAlien_Music);
        UnityEngine.Debug.Log("changing to orange music");
    }
    public void SetTo_QueenAlien_Music() 
    {
        backgroundMusic_Instance.setParameterByName("BackgroundMusic_Param", queenAlien_Music);
        UnityEngine.Debug.Log("changing to queen music");
    }
    public void SetTo_Title_Music() 
    {
        backgroundMusic_Instance.setParameterByName("BackgroundMusic_Param", title_Music);
        UnityEngine.Debug.Log("changing to title music");

    }
    #endregion
}
