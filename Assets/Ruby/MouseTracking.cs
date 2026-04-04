using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracking : MonoBehaviour
{
    private Camera mainCamera;
    private bool interactable;

    public GameObject currentOptionObj;
    private GameObject nextButton;
    private GameObject currentAlien;

    private DialogueManager DialogueManager_scr;
    private InteractionSelector InteractionSelector_scr;
    private ListOfAliens_Script ListOfAliens_Script_scr;
    private LoveMeter LoveMeter_scr;

    public int optionID;

    [SerializeField]
    private float maxSpeed;

    private void Start()
    {
        mainCamera = Camera.main;
        nextButton = GameObject.Find("Next");
        DialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        InteractionSelector_scr = GameObject.Find("GameManager").GetComponent<InteractionSelector>();
        LoveMeter_scr = GameObject.Find("LoveMeter").GetComponent<LoveMeter>();
        ListOfAliens_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();

        currentAlien = ListOfAliens_Script_scr.currentDate;//when scene starts get current alien 
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;

            FollowMousePositionDelayed(maxSpeed);

        if (interactable && mouse.leftButton.wasPressedThisFrame)//this is where the animation should be?
        {
            optionID = currentOptionObj.GetComponent<OptionSelector>().interactionID;
            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                InteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes
            DialogueManager_scr.ResponseBox(optionID);
            LoveMeter_scr.LoveChange(optionID);
            nextButton.SetActive(true);

            AnimationTrigger();//trigger animation depending on the ID of the option picked
        }
    }

    public void AnimationTrigger()
    {
        switch (optionID)//0 NEGATIVE | 1 NEUTRAL | 2 POSITIVE
        {
            case 0:
                currentAlien.GetComponent<Animator>().SetInteger("Mood", 0);

                break;
            case 1:
                currentAlien.GetComponent<Animator>().SetInteger("Mood", 1);

                break;
            case 2:
                currentAlien.GetComponent<Animator>().SetInteger("Mood", 2);

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
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(),
            maxSpeed * Time.deltaTime);
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);

    }
}
