using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySlideAnim_Script : MonoBehaviour
{
    private Animator slideAnimator;
    private TabletAppearDissapear_Script tabletMoveScript;
    //played == false


    private void Start()
    {
        slideAnimator = GetComponent<Animator>();
        tabletMoveScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
    }

    public void playSlideAnim(bool tabletOn) 
    {
        if (tabletOn == true)
        {
            slideAnimator.SetBool("onScreen", true);
            StartCoroutine(Wait());
        }
        else if (tabletOn == false) 
        {
            slideAnimator.SetBool("onScreen", false);
            slideAnimator.SetBool("played", false);
        }
    }

    IEnumerator Wait() 
    { 
        yield return new WaitForSeconds(1);
        slideAnimator.SetBool("played", true);
    }
}
