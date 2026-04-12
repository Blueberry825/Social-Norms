using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings_Script : MonoBehaviour
{
    [SerializeField] private Animator settingsAnimator;
    [SerializeField] private Animator startAreaAnimator;
    private bool settingsOpen;
    private Scene currentScene;

    private void Start()
    {
        settingsAnimator = GameObject.Find("Settings_Area").GetComponent<Animator>();
    }

    public void OpenSettings() 
    {
        settingsAnimator.SetBool("OptionsMenu", true);

        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "Opening_Scene") 
        {
            startAreaAnimator = GameObject.Find("StartArea").GetComponent<Animator>();
            startAreaAnimator.SetBool("OnScreen", false);
        }
    }


    public void CloseSettings() 
    {
        settingsAnimator.SetBool("OptionsMenu", false);
    }

    public void settingsButton() 
    { 
        //get details from settings carry

        settingsOpen = !settingsOpen;

        if (settingsOpen) 
        {
            OpenSettings();
        }

        if (!settingsOpen) 
        {
            CloseSettings();
        }
    }
}
