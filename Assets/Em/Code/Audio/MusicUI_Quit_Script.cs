using UnityEngine;

public class MusicUI_Quit_Script : MonoBehaviour
{
    public void Quit_AudioCue()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/PauseMenu/PauseMenu_Quit");
    }
}
