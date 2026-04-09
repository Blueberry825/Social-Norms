using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SwipeLeftRight_Script : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private DateRandomiser_Script dateScript;

    private FMOD.Studio.EventInstance sliderAudio;
    private bool hasAudioPlayed = false;

    private Animator tabletAnimator;

    private ListOfAliens_Script listAlienScript;
    private TabletAppearDissapear_Script TabletAppearDissapear_Script_scr;

    private void Start()
    {
        TabletAppearDissapear_Script_scr = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
        dateScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        sliderAudio = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Tablet/DatingApp/MoveSlider");

        tabletAnimator = GameObject.Find("Tablet").GetComponent<Animator>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Mouse.current.leftButton.isPressed && hasAudioPlayed == false)
        {
            sliderAudio.start();
            hasAudioPlayed = true;
        }


        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(position.x+eventData.delta.x, -200, 200), position.y, position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        hasAudioPlayed = false;
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/Reset_Slider");

        Vector3 position = transform.localPosition;
        if (position.x < 200 && position.x > -200) 
        { 
            ResetPosition(position);
        }

        if (position.x == 200) 
        {
            SwipedRight();
        }

        if (position.x == -200)
        {
            SwipedLeft();
        }
    }

    public void SwipedLeft() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/SlideButton_Dismiss");
        dateScript.RandomiseDate();
        ResetPosition(gameObject.transform.position);
    }

    public void SwipedRight() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/SlideButton_Accept");
        tabletAnimator.SetBool("Matched", true);

        Debug.Log("Swiped right.");
        TabletAppearDissapear_Script_scr.isLevelOver = false;//when player starts level they have no longer won
        dateScript.GoOnDateWith();
        ResetPosition(gameObject.transform.position);
    }

    private void ResetPosition(Vector3 position) 
    {
        Debug.Log("Reset slider position");
        tabletAnimator.SetBool("Matched", false);
        transform.localPosition = new Vector3(0, position.y, position.z);
    }

}
