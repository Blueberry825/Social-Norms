using UnityEngine;
using UnityEngine.InputSystem;

public class TabletAppearDissapear_Script : MonoBehaviour
{
    [SerializeField] private Animator tabletAnimator;
    [SerializeField] private bool tabletClicked;
    private Animator matchedTXTAnimator;
    private GameObject levelMapGO;
    private GameObject datingAppGO;
    private bool mapOnScreenBool;
    private Animator levelMapAnimator;

    private MapCharacterMovementAnim_Script mapCharacterMovementAnimScript;

    private GameObject slideBarGO;
    private DateRandomiser_Script dateRandomiserScript;


    //will also have home page, to allow swapping between 
    // - dating app (can't be accessed whilst on date)
    // - who you've dated
    // - pause menu
    // - options menu

    private void Start()
    {
        tabletAnimator = GetComponent<Animator>();
        matchedTXTAnimator = GameObject.Find("Matched_TXT").GetComponent<Animator>();

        mapCharacterMovementAnimScript = gameObject.GetComponent<MapCharacterMovementAnim_Script>();

        levelMapGO = GameObject.Find("Level_Map");
        datingAppGO = GameObject.Find("DatingApp");
        levelMapAnimator = levelMapGO.GetComponent<Animator>();
        slideBarGO = GameObject.Find("LoveHeart_Slide");
        dateRandomiserScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
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

    public void MatchedAnimations() 
    {
        matchedTXTAnimator.ResetTrigger("Reset");
        matchedTXTAnimator.ResetTrigger("Matched_Trigger");
        matchedTXTAnimator.SetTrigger("Matched_Trigger");
    }

    public void SwapMapVisibility() //called once matched txt anim ends
    {
        datingAppGO.SetActive(false);
        mapOnScreenBool = levelMapAnimator.GetBool("MapOnScreen");

        if (mapOnScreenBool == true)
        {
            levelMapAnimator.SetBool("MapOnScreen", false );
        }
        else 
        {
            levelMapAnimator.SetBool("MapOnScreen", true);
        }
        mapCharacterMovementAnimScript.MapCharacterMovementAnims();     
    }

    public void MapOnOff(bool State) //called once matched txt anim ends
    {
        levelMapAnimator.SetBool("MapOnScreen", State);
    }
 

    //public void RefreshAnimations()
    //{

    //}

}
