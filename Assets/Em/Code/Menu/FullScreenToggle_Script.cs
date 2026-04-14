using TMPro;
using UnityEngine;

public class FullScreenToggle_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fullscreen_TXT;
    [SerializeField] private TextMeshProUGUI windowed_TXT;
    [SerializeField] private bool fullscreen_b;
    private BackgroundMusic_Script bgm_Script;

    private void Start()
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        fullscreen_b = bgm_Script.fullScreen;

        if (fullscreen_b == true)
        {
            fullscreen_TXT.gameObject.SetActive(true);
            windowed_TXT.gameObject.SetActive(false);
        }
        else
        {
            fullscreen_TXT.gameObject.SetActive(false);
            windowed_TXT.gameObject.SetActive(true);
        }

    }

    public void initialise() 
    {
        bgm_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        fullscreen_b = bgm_Script.fullScreen;

        if (fullscreen_b == true)
        {
            fullscreen_TXT.gameObject.SetActive(true);
            windowed_TXT.gameObject.SetActive(false);
        }
        else
        {
            fullscreen_TXT.gameObject.SetActive(false);
            windowed_TXT.gameObject.SetActive(true);
        }
    }

    public void FullScreen() 
    { 
        Screen.fullScreen = !Screen.fullScreen;
        fullscreen_b = !fullscreen_b;
        Swap();
    }

    private void Swap() 
    {
        if (fullscreen_b == true) 
        {
            fullscreen_TXT.gameObject.SetActive(true);
            windowed_TXT.gameObject.SetActive(false);
        }
        else
        {
            fullscreen_TXT.gameObject.SetActive(false);
            windowed_TXT.gameObject.SetActive(true);
        }
        bgm_Script.fullScreen = fullscreen_b;
    }
}
