using UnityEngine;

public class TextAppearHideTabletStuff_Scrpt : MonoBehaviour
{
    private Animator datingAppAnimator;

    private void Start()
    {
        datingAppAnimator = GameObject.Find("Tablet").GetComponent<Animator>();
    }

    public void MatchedTextOnScreen_HideStuff() //called from animators
    {
        datingAppAnimator.SetBool("TextOnScreen", true);
    }


    public void MatchedTextDone()//called from animators
    {
        datingAppAnimator.SetBool("TextOnScreen", false);
    }
}
