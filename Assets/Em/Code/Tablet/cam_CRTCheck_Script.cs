using BrewedInk.CRT;
using UnityEngine;

public class cam_CRTCheck_Script : MonoBehaviour
{
    private CRTCameraBehaviour crtCamera;
    private BackgroundMusic_Script bgm_Script;

    private void Start()
    {
        crtCamera = GetComponent<CRTCameraBehaviour>();
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();

        if (bgm_Script.bgm_crtToggle == true) 
        {
            crtCamera.enabled = true;
        }
        if (bgm_Script.bgm_crtToggle == false) 
        { 
            crtCamera.enabled = false;
        }
    }
}
