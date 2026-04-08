using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicUI_SliderChange_Script : MonoBehaviour
{
    public void sliderChanged_AudioCue() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/MoveSlider");
    }

}
