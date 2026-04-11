using UnityEngine;

public class OpenSettings_Script : MonoBehaviour
{
    [SerializeField] private Animator settingsAnimator;
    private bool settingsOpen;

    private void Start()
    {
        settingsAnimator = GameObject.Find("Settings_Area").GetComponent<Animator>();
    }

    public void OpenSettings() 
    {
        settingsAnimator.SetBool("OptionsMenu", true);
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
            settingsAnimator.SetBool("OptionsMenu", true);
        }

        if (!settingsOpen) 
        {
            settingsAnimator.SetBool("OptionsMenu", false);
        }
    }
}
