using UnityEngine;
using UnityEngine.InputSystem;

public class TabletAppearDissapear_Script : MonoBehaviour
{
    [SerializeField] private Animator tabletAnimator;
    [SerializeField] private bool tabletClicked;
    private Animator matchedTXTAnimator;
    private GameObject levelMapGO;
    private Animator levelMapAnimator;
    private bool mapOnScreenBool;


    private MapCharacterMovementAnim_Script mapCharacterMovementAnimScript;


    public bool isLevelOver;

    public bool tabletOnScreenBool;

    //will also have home page, to allow swapping between 
    // - dating app (can't be accessed whilst on date)
    // - who you've dated
    // - pause menu
    // - options menu

    private void Start()
    {
        isLevelOver = true;
        tabletAnimator = GetComponent<Animator>();
        matchedTXTAnimator = GameObject.Find("Matched_TXT").GetComponent<Animator>();

        mapCharacterMovementAnimScript = gameObject.GetComponent<MapCharacterMovementAnim_Script>();

        levelMapGO = GameObject.Find("Level_Map");
        levelMapAnimator = levelMapGO.GetComponent<Animator>();
    }

    private void Update()
    {
        bool spaceKeyPressed = Keyboard.current.spaceKey.wasPressedThisFrame;
        bool spaceKeyPressed2 = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (spaceKeyPressed || spaceKeyPressed2 && isLevelOver) 
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
            tabletOnScreenBool = false;
        }
        else 
        {
            tabletAnimator.SetBool("TabletOnScreen", true);
            tabletOnScreenBool = true;
        }
    }

    public void MatchedAnimations() 
    {
        matchedTXTAnimator.SetTrigger("Matched_Trigger");
    }

    public void SwapMapVisibility() //called once matched txt anim ends
    {
        mapOnScreenBool = levelMapAnimator.GetBool("MapOnScreen");

        if (mapOnScreenBool == true)
        {
            levelMapAnimator.SetBool("MapOnScreen", false);
        }
        else 
        {
            levelMapAnimator.SetBool("MapOnScreen", true);
        }
        mapCharacterMovementAnimScript.MapCharacterMovementAnims();        
    }

    public void MapOnOff(bool OnOff) //called once matched txt anim ends
    {
        levelMapAnimator.SetBool("MapOnScreen", OnOff);
    }
}
