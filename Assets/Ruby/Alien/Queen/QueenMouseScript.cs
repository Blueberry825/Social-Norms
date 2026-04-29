using UnityEngine;
using UnityEngine.InputSystem;

public class QueenMouseScript : MonoBehaviour
{
    private Camera mainCamera;
    private bool interactable;

    public GameObject currentOptionObj;
    private GameObject nextButton;
    public GameObject queen;

    private QueenDialogue QueenDialogue_scr;
    private QueenInteractionSelector QueenInteractionSelector_scr;
    private ListOfAliens_Script ListOfAliens_Script_scr;
    private LoveMeter LoveMeter_scr;
    private BackgroundMusic_Script backgroundMusic_scr;

    public int optionID;

    [SerializeField]
    public float maxSpeed;

    private void Start()
    {
        mainCamera = Camera.main;
        nextButton = GameObject.Find("Next");
        QueenDialogue_scr = GameObject.Find("QueenDialogue").GetComponent<QueenDialogue>();
        QueenInteractionSelector_scr = GameObject.Find("GameManager").GetComponent<QueenInteractionSelector>();
        LoveMeter_scr = GameObject.Find("LoveMeter").GetComponent<LoveMeter>();     
        //backgroundMusic_scr = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>(); //TEMPORARY

        //maxSpeed = backgroundMusic_scr.mouseSensitivity * 10; TEMP
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;

        FollowMousePositionDelayed(maxSpeed);

        if (interactable && mouse.leftButton.wasPressedThisFrame)//this is where the animation should be?
        {
            optionID = currentOptionObj.GetComponent<OptionSelector>().interactionID;
            for (int i = 0; i < QueenInteractionSelector_scr.optionTextBoxes.Count; i++)
                QueenInteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes
            QueenDialogue_scr.ResponseBox(optionID);
            LoveMeter_scr.LoveChange(optionID);
            nextButton.SetActive(true);

            AnimationTrigger();
        }
    }

    public void AnimationTrigger()
    {
        switch (optionID)//0 NEGATIVE | 1 NEUTRAL | 2 POSITIVE
        {
            case 0:
                queen.GetComponent<Animator>().SetTrigger("Negative");

                break;
            case 1:
                queen.GetComponent<Animator>().SetTrigger("Neutral");

                break;
            case 2:
                queen.GetComponent<Animator>().SetTrigger("Positive");

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//enter trigger space 
    {
        if (collision.CompareTag("option"))
        {
            interactable = true;
            currentOptionObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//leave trigger space 
    {
        if (collision.CompareTag("option"))
        {
            interactable = false;
        }
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private void FollowMousePositionDelayed(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);

    }
}

