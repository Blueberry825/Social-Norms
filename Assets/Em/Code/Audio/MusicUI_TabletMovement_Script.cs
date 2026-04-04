using UnityEngine;

public class MusicUI_TabletMovement_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance tabletMovement_audio;


    private void Start()
    {
        tabletMovement_audio = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Tablet/Tablet_Movement");
    }

    public void TabletMovementON_AudioCue() 
    {
        tabletMovement_audio.setParameterByName("Tablet_Movement_Param", 0);
        tabletMovement_audio.start();
    }

    public void TabletMovementOFF_AudioCue()
    {
        tabletMovement_audio.setParameterByName("Tablet_Movement_Param", 1);
        tabletMovement_audio.start();
    }
}
