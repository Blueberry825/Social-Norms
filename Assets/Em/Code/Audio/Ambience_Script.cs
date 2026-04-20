using UnityEngine;
using UnityEngine.SceneManagement;

public class Ambience_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance ambience_Instance;
    private int alienNumber_amb;
    private DateRandomiser_Script dateRandomiser_Script;
    private GameObject alienOnScreen_;
    private AliensDated_Script alienScript;

    private Scene currentScene;

    private void Start()
    {
        //put on camera for date scene
        ambience_Instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Ambience");
        ambience_Instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        dateRandomiser_Script = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        alienOnScreen_ = dateRandomiser_Script.alienOnScreen;
        alienScript = alienOnScreen_.GetComponent<AliensDated_Script>();

        alienNumber_amb = alienScript.alienNumber;

        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Date_Scene" && IsPlaying(ambience_Instance) == false)
        {
            Debug.Log("Playing ambi");
            SetAlienAmbience(alienNumber_amb);
            ambience_Instance.start();
        }
        else if (currentScene.name != "Date_Scene") 
        {
            Debug.Log("Stopping ambi");
            //stop ambi
            ambience_Instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
    public bool IsPlaying(FMOD.Studio.EventInstance instance) //checks if already playing
    {
        FMOD.Studio.PLAYBACK_STATE currentMusicState;
        instance.getPlaybackState(out currentMusicState);
        return currentMusicState != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }

    private void SetAlienAmbience(int alienNumber) 
    {
        Debug.Log("Setting ambi to " + alienNumber);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ambi_AlienNum", alienNumber);
    }
}
