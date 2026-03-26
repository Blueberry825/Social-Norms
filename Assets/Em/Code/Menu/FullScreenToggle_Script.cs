using TMPro;
using UnityEngine;

public class FullScreenToggle_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fullscreen_TXT;
    [SerializeField] private TextMeshProUGUI windowed_TXT;
    private bool fullscreen_b;

    private void Start()
    {
        fullscreen_TXT.gameObject.SetActive(true);
        windowed_TXT.gameObject.SetActive(false);
        fullscreen_b = true;
    }

    public void FullScreen() 
    { 
        Screen.fullScreen = !Screen.fullScreen;
        fullscreen_b = !fullscreen_b;
        Swap();
        Debug.Log("Changed scene mode");
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
    }
}
