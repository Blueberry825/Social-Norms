using UnityEngine;
using UnityEngine.SceneManagement;

public class Ambience_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance ambience_Instance;
    [SerializeField] private int alienNumber_amb;
    private DateRandomiser_Script dateRandomiser_Script;
    [SerializeField] private GameObject alienOnScreen_;
    private AliensDated_Script alienScript;

    private Scene currentScene;
    //[SerializeField] private bool ambiPlaying;


    private void Start()
    {
        ambience_Instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Ambience");
        ambience_Instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void startAmbience()
    {

        dateRandomiser_Script = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        alienOnScreen_ = dateRandomiser_Script.alienOnScreen;
        alienScript = alienOnScreen_.GetComponent<AliensDated_Script>();
        alienNumber_amb = alienScript.alienNumber;

        ambience_Instance.start();
        SetAlienAmbience(alienNumber_amb);

        Debug.Log("starting ambi");

    }

    public void stopAmbience()
    {
        if (IsPlaying(ambience_Instance) == true) 
        {
            ambience_Instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Debug.Log("stopping ambi");
        }
    }


    private bool IsPlaying(FMOD.Studio.EventInstance instance) //checks if already playing
    {
        FMOD.Studio.PLAYBACK_STATE currentMusicState;
        instance.getPlaybackState(out currentMusicState);
        return currentMusicState != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

    private void SetAlienAmbience(int alienNumber)
    {
        Debug.Log("set alienNumber ambi to " + alienNumber);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ambi_AlienNum", alienNumber);
    }
}
