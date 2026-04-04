using UnityEngine;

public class MusicUI_Click_Script : MonoBehaviour
{
    public void Click_AudioCue() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Clicking");
    }

    public void ClickB_AudioCue() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Clicking_B");

    }
}
