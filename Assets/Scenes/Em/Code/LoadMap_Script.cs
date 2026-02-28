using UnityEngine;

public class LoadMap_Script : MonoBehaviour
{
    private TabletAppearDissapear_Script tabletAnimScript;
    private Animator matchedAnimator;

    private void Start()
    {
        tabletAnimScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
        matchedAnimator = gameObject.GetComponent<Animator>();
    }
    private void MatchedAnimDone() 
    {
        tabletAnimScript.SwapMapVisibility();
        matchedAnimator.SetTrigger("Reset");
    }
}
