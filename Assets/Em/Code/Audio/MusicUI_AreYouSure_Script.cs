using UnityEngine;

public class MusicUI_AreYouSure_Script : MonoBehaviour
{
    public void AreYouSure_AudioCue() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/PauseMenu/PauseMenu_AreYouSure");
    }
}
