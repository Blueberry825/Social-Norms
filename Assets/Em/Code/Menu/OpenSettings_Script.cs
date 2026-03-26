using UnityEngine;

public class OpenSettings_Script : MonoBehaviour
{
    private Animator settingsAnimator;

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
}
