using UnityEngine;

public class CreditsButton_Script : MonoBehaviour
{
    private Animator creditsAnimator;

    private void Start()
    {
        creditsAnimator = GameObject.Find("Credits_Area").GetComponent<Animator>();
    }
    public void OpenCredits() 
    {
        creditsAnimator.SetBool("Credits", true);
    }

    public void CloseCredits() 
    {
        creditsAnimator.SetBool("Credits", false);
    }
}
