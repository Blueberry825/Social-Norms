using FMOD;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuStuff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private bool onScreen;
    [SerializeField] GameObject locationDetails;

    public void OnPointerEnter(PointerEventData eventData)
    {
        onScreen = true;
        locationDetails.SetActive(true);
        print("true");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onScreen = false;
        locationDetails.SetActive(false);
        print("false");
    }

}

