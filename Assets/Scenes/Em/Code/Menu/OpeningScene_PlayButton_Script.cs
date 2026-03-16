using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene_PlayButton_Script : MonoBehaviour
{
    private Animator fadeoutAnimator;

    private void Start()
    {
        fadeoutAnimator = GameObject.Find("FadeOut_IMG").GetComponent<Animator>();
    }
    public void FadeOutAnimation() 
    {
        //animator, then called through that instead

        fadeoutAnimator.SetBool("FadeOut", true);
    }

    public void FadeOutDone() 
    {
        fadeoutAnimator.SetBool("FadeOut", false);
        SceneManager.LoadScene("Title_Scene");
    }


}
