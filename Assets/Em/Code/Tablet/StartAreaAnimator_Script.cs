using UnityEngine;

public class StartAreaAnimator_Script : MonoBehaviour
{
    [SerializeField] private Animator startAreaAnimator;
    [SerializeField] private bool onScreen_B;

    private void Start()
    {
        startAreaAnimator = GameObject.Find("StartArea").GetComponent<Animator>();
    }

    public void startButtonClicked() 
    {
        onScreen_B = !onScreen_B;

        if (onScreen_B == true)
        {
            startAreaAnimator.SetBool("OnScreen", true);
        }

        if (onScreen_B == false)
        {
            startAreaAnimator.SetBool("OnScreen", false);
        }
    }
}
