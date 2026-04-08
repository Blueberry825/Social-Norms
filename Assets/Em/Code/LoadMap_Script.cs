using UnityEngine;

public class LoadMap_Script : MonoBehaviour
{
    private TabletAppearDissapear_Script tabletAnimScript;

    private void Start()
    {
        tabletAnimScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
    }
    private void MatchedAnimDone() //found at the end of matchtxt appear animation
    {
        tabletAnimScript.SwapMapVisibility();
    }
}
