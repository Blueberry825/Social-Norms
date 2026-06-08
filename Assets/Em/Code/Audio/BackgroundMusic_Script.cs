using FMOD;
using FMOD.Studio;
using FMODUnity;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance backgroundMusic_Instance;

    [SerializeField] private TextMeshProUGUI MasterVolume_Number; 
    [SerializeField] private TextMeshProUGUI MusicVolume_Number;
    [SerializeField] private TextMeshProUGUI SFXVolume_Number;
    [SerializeField] private int masterTXTNumber;
    [SerializeField] private int musicTXTNumber;
    [SerializeField] private int sfxTXTNumber;

    [SerializeField] private GameObject masterVolume_icon;
    [SerializeField] private GameObject sfxVolume_icon;
    [SerializeField] private GameObject musicVolume_icon;
    [SerializeField] private Animator msV_anim;
    [SerializeField] private Animator musicV_anim;
    [SerializeField] private Animator sfxV_anim;
    [SerializeField] private GameObject masterScroll;
    [SerializeField] private GameObject musicScroll;
    [SerializeField] private GameObject sfxScroll;

    private bool pauseBool = false;
    private int pauseValue = 0;

    private DateRandomiser_Script dateRandomiser_Script;
    private GameObject alienOnScreen_;

    public bool fullScreen;
    public float mouseSensitivity = 0.5f;
    public bool bgm_crtToggle = true;
    public bool bgmStartLoc_b;

    FMOD.Studio.EventInstance badReply_snapshot;
    FMOD.Studio.EventInstance pauseMenu_snapshot;
    FMOD.Studio.EventInstance textStreaming_snapshot;

    #region slider audio clicks
    private string lastNum;
    private string currentNum;
    #endregion

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

    FMOD.Studio.Bus ambiBus;
    #endregion

    private Ambience_Script ambiScript;

    private void Start()
    {
        backgroundMusic_Instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BackgroundMusic_Music");
        Master_Bus = Music_Bus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus");
        Music_Bus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus/BackgroundMusic_Bus");
        SFX_Bus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus/SFX_Bus");
        ambiBus = FMODUnity.RuntimeManager.GetBus("bus:/Master_Bus/Ambience_Bus");

        ambiScript = GameObject.Find("Ambience_Holder").GetComponent<Ambience_Script>();
        badReply_snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/BadReply_Snapshot");
        pauseMenu_snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Pause_Snapshot");
        textStreaming_snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/TextStreaming_Snapshot");

        GetAndSetSettings();
        SetTo_Title_Music();
        StartBackgroundMusic();
    }

    public void TextStreamingSnapshot(bool value) 
    {
        if (value == true)
        {
            textStreaming_snapshot.start();
        }

        else if (value == false) 
        { 
            textStreaming_snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void BadReplySnapshot() 
    {
        badReply_snapshot.start();
        StartCoroutine(waitSeconds());
    }

    IEnumerator waitSeconds() 
    { 
        yield return new WaitForSeconds(2);
        badReply_snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void bgmStartLoc() 
    {
        if (bgmStartLoc_b)
        {
            backgroundMusic_Instance.setParameterByName("skipTyping_Param", 1);
        }

        else 
        {
            backgroundMusic_Instance.setParameterByName("skipTyping_Param", 0);
        }
    }

    public void MasterVolumeSliderChanged(float newMasterVolume)
    {
        Master_Volume = newMasterVolume;
        Master_Bus.setVolume(Master_Volume);
        masterTXTNumber = Mathf.RoundToInt(Master_Volume * 10);
        MasterVolume_Number.text = masterTXTNumber.ToString("F0");
        msV_anim.SetInteger("Volume", masterTXTNumber);

        if (MasterVolume_Number.text == "0" || MasterVolume_Number.text == "1" || MasterVolume_Number.text == "2" || MasterVolume_Number.text == "3" || MasterVolume_Number.text == "4" || MasterVolume_Number.text == "5" || MasterVolume_Number.text == "6" || MasterVolume_Number.text == "7" || MasterVolume_Number.text == "8" || MasterVolume_Number.text == "9" || MasterVolume_Number.text == "10")
        {
            currentNum = MasterVolume_Number.text.ToString();

            if (currentNum != lastNum)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Click_Low");
            }
            lastNum = currentNum;
        }
    }

    public void MusicVolumeSliderChanged(float newMuiscVolume)
    {
        Music_Volume = newMuiscVolume;
        Music_Bus.setVolume(Music_Volume);
        musicTXTNumber = Mathf.RoundToInt(Music_Volume * 10);
        MusicVolume_Number.text = musicTXTNumber.ToString("F0");

        musicV_anim.SetInteger("Volume", musicTXTNumber);

        if (MusicVolume_Number.text == "0" || MusicVolume_Number.text == "1" || MusicVolume_Number.text == "2" || MusicVolume_Number.text == "3" || MusicVolume_Number.text == "4" || MusicVolume_Number.text == "5" || MusicVolume_Number.text == "6" || MusicVolume_Number.text == "7" || MusicVolume_Number.text == "8" || MusicVolume_Number.text == "9" || MusicVolume_Number.text == "10")
        {
            currentNum = MusicVolume_Number.text.ToString();

            if (currentNum != lastNum)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Click_Low");
            }
            lastNum = currentNum;
        }
    }

    public void SFXVolumeSliderChanged(float newSFXVolume)
    {
        SFX_Volume = newSFXVolume;
        SFX_Bus.setVolume(SFX_Volume);
        sfxTXTNumber = Mathf.RoundToInt(SFX_Volume * 10);
        SFXVolume_Number.text = sfxTXTNumber.ToString("F0");
        sfxV_anim.SetInteger("Volume", sfxTXTNumber);

        if (SFXVolume_Number.text == "0" || SFXVolume_Number.text == "1" || SFXVolume_Number.text == "2" || SFXVolume_Number.text == "3" || SFXVolume_Number.text == "4" || SFXVolume_Number.text == "5" || SFXVolume_Number.text == "6" || SFXVolume_Number.text == "7" || SFXVolume_Number.text == "8" || SFXVolume_Number.text == "9" || SFXVolume_Number.text == "10")
        {
            currentNum = SFXVolume_Number.text.ToString();

            if (currentNum != lastNum)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Click_Low");
            }
            lastNum = currentNum;
        }
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
    public void StopBackgroundMusic() 
    {
        backgroundMusic_Instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


    public void PauseMenuBackgroundMusic()
    {
        pauseBool = !pauseBool;

        if (pauseBool == false)
        {
            pauseValue = 0;
            pauseMenu_snapshot.start();
        }
        else if (pauseBool == true)
        {
            pauseValue = 1;
            pauseMenu_snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("IsGamePaused", pauseValue);

    }
    #endregion

    public void SceneChanged_AudioCheck(string sceneName)
    {
        GetAndSetSettings();

        if (sceneName == "Date_Scene")
        {
            ambiScript.startAmbience();

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
            ambiScript.stopAmbience();
        }

        if (sceneName == "Queen_Scene") 
        {
            SetTo_QueenAlien_Music();
        }
    }

    public void GetAndSetSettings() 
    {
        MasterVolume_Number = GameObject.Find("Master_Number_TXT").GetComponent<TextMeshProUGUI>();
        MusicVolume_Number = GameObject.Find("BackgroundMusic_Number_TXT").GetComponent<TextMeshProUGUI>();
        SFXVolume_Number = GameObject.Find("SFX_Number_TXT").GetComponent<TextMeshProUGUI>();

        masterVolume_icon = GameObject.Find("Master_IMG");
        musicVolume_icon = GameObject.Find("BackgroundMusic_IMG");
        sfxVolume_icon = GameObject.Find("SFX_IMG");

        msV_anim = masterVolume_icon.GetComponent<Animator>();
        musicV_anim = musicVolume_icon.GetComponent<Animator>();
        sfxV_anim = sfxVolume_icon.GetComponent<Animator>();

        masterScroll = GameObject.Find("MasterVolume_Scroll");
        musicScroll = GameObject.Find("BackgroundMusic_Scroll");
        sfxScroll = GameObject.Find("SFX_Scroll");


        masterScroll.GetComponent<Scrollbar>().value = Master_Volume;
        musicScroll.GetComponent<Scrollbar>().value = Music_Volume;
        sfxScroll.GetComponent<Scrollbar>().value = SFX_Volume;


        MasterVolume_Number.text = masterTXTNumber.ToString("F0");
        msV_anim.SetInteger("Volume", masterTXTNumber);
        SFXVolume_Number.text = sfxTXTNumber.ToString("F0");
        sfxV_anim.SetInteger("Volume", sfxTXTNumber);
        SFXVolume_Number.text = sfxTXTNumber.ToString("F0");
        sfxV_anim.SetInteger("Volume", sfxTXTNumber);

    }

    #region Setting Background Music
    public void SetTo_PurpleAlien_Music()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BackgroundMusic_Param", purpleAlien_Music);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("IsGamePaused", 0);

        UnityEngine.Debug.Log("changing to purple music");
    }
    public void SetTo_GreenAlien_Music()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BackgroundMusic_Param", greenAlien_Music);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("IsGamePaused", 0);

        UnityEngine.Debug.Log("changing to green music");
    }
    public void SetTo_OrangeAlien_Music()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BackgroundMusic_Param", orangeAlien_Music);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("IsGamePaused", 0);

        UnityEngine.Debug.Log("changing to orange music");
    }
    public void SetTo_QueenAlien_Music()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BackgroundMusic_Param", queenAlien_Music);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("IsGamePaused", 0);

        UnityEngine.Debug.Log("changing to queen music");
    }
    public void SetTo_Title_Music()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("BackgroundMusic_Param", title_Music);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("IsGamePaused", 0);

        UnityEngine.Debug.Log("changing to title music");

    }
    #endregion
}
