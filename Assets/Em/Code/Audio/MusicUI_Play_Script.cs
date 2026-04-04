using UnityEngine;

public class MusicUI_Play_Script : MonoBehaviour
{
    public void Play_AudioCue()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/PauseMenu/PauseMenu_Play");
    }
}
