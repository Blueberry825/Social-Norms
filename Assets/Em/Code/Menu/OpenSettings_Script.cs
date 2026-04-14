using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings_Script : MonoBehaviour
{
    [SerializeField] private Animator settingsAnimator;
    [SerializeField] private StartAreaAnimator_Script startAreaAnimator;
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
            startAreaAnimator = GameObject.Find("Taskbar").GetComponent<StartAreaAnimator_Script>();
            startAreaAnimator.startButtonClicked();
        }
    }


    public void CloseSettings() 
    {
        settingsAnimator.SetBool("OptionsMenu", false);

        currentScene = SceneManager.GetActiveScene();

        //if (currentScene.name != "Opening_Scene")
        {
            //startAreaAnimator = GameObject.Find("Taskbar").GetComponent<StartAreaAnimator_Script>();
            //startAreaAnimator.startButtonClicked();
        }
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
