using FMOD;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuStuff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject locationDetails;

    public void OnPointerEnter(PointerEventData eventData)
    {
        locationDetails.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        locationDetails.SetActive(false);
    }

}

