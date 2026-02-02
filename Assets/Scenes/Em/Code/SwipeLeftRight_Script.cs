using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SwipeLeftRight_Script : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private DateRandomiser_Script dateScript;
    private ListOfAliens_Script listAlienScript;


    private void Start()
    {
        dateScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(position.x+eventData.delta.x, -200, 200), position.y, position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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
        Debug.Log("Swiped left.");
        dateScript.RandomiseDate();
        ResetPosition(gameObject.transform.position);
    }

    public void SwipedRight() 
    {
        Debug.Log("Swiped right.");
        dateScript.GoOnDateWith();
    }

    private void ResetPosition(Vector3 position) 
    {
        Debug.Log("Reset slider position.");
        transform.localPosition = new Vector3(0, position.y, position.z);
    }

}
