using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracking : MonoBehaviour
{
    private Camera mainCamera;
    private bool interactable;

    public GameObject currentOptionObj;

    private DialogueManager DialogueManager_scr;
    private InteractionSelector InteractionSelector_scr;

    public int optionID;

    [SerializeField]
    private float maxSpeed;

    private void Start()
    {
        mainCamera = Camera.main;
        DialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        InteractionSelector_scr = GameObject.Find("GameManager").GetComponent<InteractionSelector>();
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;

            FollowMousePositionDelayed(maxSpeed);

        if (interactable && mouse.leftButton.wasPressedThisFrame)
        {
            optionID = currentOptionObj.GetComponent<OptionSelector>().interactionID;
            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                InteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes
            DialogueManager_scr.ResponseBox(optionID);
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
