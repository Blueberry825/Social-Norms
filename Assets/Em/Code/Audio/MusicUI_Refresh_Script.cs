using UnityEngine;

public class MusicUI_Refresh_Script : MonoBehaviour
{
    public void Refresh_AudioCue()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/Refresh_Text");

    }
}
