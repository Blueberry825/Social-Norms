using UnityEngine;

public class TextAppearHideTabletStuff_Scrpt : MonoBehaviour
{
    private Animator datingAppAnimator;

    private void Start()
    {
        datingAppAnimator = GameObject.Find("Tablet").GetComponent<Animator>();
    }

    public void MatchedTextOnScreen_HideStuff() 
    {
        datingAppAnimator.SetBool("TextOnScreen", true);
    }


    public void MatchedTextDone()
    {
        datingAppAnimator.SetBool("TextOnScreen", false);
    }
}
