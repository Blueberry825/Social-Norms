using BrewedInk.CRT;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CRTToggle_Script : MonoBehaviour
{
    public bool crtToggle;
    private BackgroundMusic_Script bgm_Script;
    [SerializeField] private TextMeshProUGUI off_TXT;
    [SerializeField] private TextMeshProUGUI on_TXT;
    [SerializeField] private CRTCameraBehaviour crtCam;

    private void Start()
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        off_TXT = GameObject.Find("Off_TXT").GetComponent<TextMeshProUGUI>();
        on_TXT = GameObject.Find("On_TXT").GetComponent<TextMeshProUGUI>();


        crtToggle = bgm_Script.bgm_crtToggle;

        if (crtToggle == true) 
        { 
            on_TXT.gameObject.SetActive(true);
            off_TXT.gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().name != "Opening_Scene")
            {
                crtCam = GameObject.Find("Main Camera").GetComponent<CRTCameraBehaviour>();
                crtCam.enabled = true;
            }
        }
        if (crtToggle == false) 
        {
            on_TXT.gameObject.SetActive(false);
            off_TXT.gameObject.SetActive(true);
            if (SceneManager.GetActiveScene().name != "Opening_Scene")
            {
                crtCam = GameObject.Find("Main Camera").GetComponent<CRTCameraBehaviour>();
                crtCam.enabled = false;
            }
        }



    }

    public void clickedCRTTogle() 
    {
        crtToggle = !crtToggle;
        bgm_Script.bgm_crtToggle = crtToggle;


        if (crtToggle)
        {
            on_TXT.gameObject.SetActive(true);
            off_TXT.gameObject.SetActive(false);
            crtCam = GameObject.Find("Main Camera").GetComponent<CRTCameraBehaviour>();
            crtCam.enabled = true;
        }

        if (!crtToggle)
        {
            on_TXT.gameObject.SetActive(false);
            off_TXT.gameObject.SetActive(true);
            crtCam = GameObject.Find("Main Camera").GetComponent<CRTCameraBehaviour>();
            crtCam.enabled = false;
        }
    }

}
