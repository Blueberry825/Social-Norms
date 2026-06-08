using UnityEngine;

public class IntroAudio_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance introInstance;

    private void Start()
    {
        introInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Intro/Intro");
    }

    public void startIntroAudio() 
    {
        introInstance.start();
    }

    public void stopIntroAudio() 
    { 
        introInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
