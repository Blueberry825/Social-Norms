using BrewedInk.CRT;
using Unity.VisualScripting;
using UnityEngine;

public class CRTEffectEditing : MonoBehaviour
{
    private CRTCameraBehaviour CRTCameraBehaviour_scr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CRTCameraBehaviour_scr = GetComponent<CRTCameraBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreasePixelationAmount(int value)
    {
        CRTCameraBehaviour_scr.data.pixelationAmount += value;
    }
}
