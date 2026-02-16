using UnityEngine;
using UnityEngine.InputSystem;

public class TabletAppearDissapear_Script : MonoBehaviour
{
    [SerializeField] private Animator tabletAnimator;
    [SerializeField] private bool tabletClicked;

    //will also have home page, to allow swapping between 
    // - dating app (can't be accessed whilst on date)
    // - who you've dated
    // - pause menu
    // - options menu

    private void Start()
    {
        tabletAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool spaceKeyPressed = Keyboard.current.spaceKey.wasPressedThisFrame;
        bool spaceKeyPressed2 = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (spaceKeyPressed || spaceKeyPressed2) 
        {
            SwapTabletVisibility();
        }
    }

    public void SwapTabletVisibility() 
    {
        Debug.Log("Tablet anims");

        tabletClicked = tabletAnimator.GetBool("TabletOnScreen");

        if (tabletClicked == true)
        {
            tabletAnimator.SetBool("TabletOnScreen", false);
        }
        else 
        {
            tabletAnimator.SetBool("TabletOnScreen", true);
        }
    }
}
