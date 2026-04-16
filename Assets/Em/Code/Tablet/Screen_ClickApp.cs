using UnityEngine;

public class Screen_ClickApp : MonoBehaviour
{
    [SerializeField] private TabletAppearDissapear_Script tabletScript;
    private Animator animator;

    private void Start()
    {
        if (gameObject.name == "DateAppArea")
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    public void clicked() 
    {
        tabletScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
        tabletScript.SwapTabletVisibility();

        if (gameObject.name == "DateAppArea")
        {
            animator.SetTrigger("clicked");
        }
    }
}
