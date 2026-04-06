using UnityEngine;

public class MusicUI_Matched_Script : MonoBehaviour
{
    public void Matched_AudioCue() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/Matched_Text");
    }
}
