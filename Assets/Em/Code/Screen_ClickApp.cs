using UnityEngine;

public class Screen_ClickApp : MonoBehaviour
{
    private TabletAppearDissapear_Script tabletScript;
    private Animator animator;

    private void Start()
    {
        tabletScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void clicked() 
    { 
        tabletScript.SwapTabletVisibility();
        animator.SetTrigger("clicked");
    }
}
