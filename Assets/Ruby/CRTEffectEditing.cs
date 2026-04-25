using BrewedInk.CRT;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CRTEffectEditing : MonoBehaviour
{
    public bool isEffectActive;

    private float effectTimer;
    private float timerDecreaseAmount = 2;
    private int frequency;

    private int effectNumber;

    private CRTCameraBehaviour CRTCameraBehaviour_scr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frequency = 30;
        effectTimer = 15;
        CRTCameraBehaviour_scr = GetComponent<CRTCameraBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEffectActive)
        {
            effectTimer -= timerDecreaseAmount * Time.deltaTime;

            var randInt = UnityEngine.Random.Range(0, frequency);//keep spawing new numbers every frame, if frame is certain number, trigger distortion effect to change

            if (randInt == 4)
            {
                EffectChooser();
            }

            if (effectTimer <= 0)//if timer is over
            {
                isEffectActive = false;//stop effect
                effectTimer = 30;
                ResetEffects();// reset crt
            }
        }       
    }

    public void EffectChooser()
    {
        switch(effectNumber)
        {
              case 0:
                frequency = 30;
                GlitchEffect();
              break;
              
              case 1:
                frequency = 50;
                QueenDistortEffectn();
              break;

              case 2:
                WaterDistortEffect();
              break;
        }
    }


    public void GlitchEffect()//set to new value when starting and reset to old value at end //effectNumber 0
    {
        CRTCameraBehaviour_scr.data.pixelationAmount = UnityEngine.Random.Range(0, 3);
        CRTCameraBehaviour_scr.data.vignette = UnityEngine.Random.Range(0.4f, 1.4f);
        CRTCameraBehaviour_scr.data.dithering4 = UnityEngine.Random.Range(0, 3);
    }

    public void QueenDistortEffectn()//set to new value when starting and reset to old value at end //effectNumber 1
    {
        CRTCameraBehaviour_scr.data.pixelationAmount = UnityEngine.Random.Range(0, 3);
        CRTCameraBehaviour_scr.data.vignette = UnityEngine.Random.Range(4f, 8f);
        CRTCameraBehaviour_scr.data.dithering4 = UnityEngine.Random.Range(0, 0);
    }

    public void WaterDistortEffect()//set to new value when starting and reset to old value at end //effectNumber 1
    {
        CRTCameraBehaviour_scr.data.pixelationAmount = UnityEngine.Random.Range(0, 3);
        CRTCameraBehaviour_scr.data.vignette = UnityEngine.Random.Range(4f, 8f);
        CRTCameraBehaviour_scr.data.dithering4 = UnityEngine.Random.Range(0, 0);
    }

    public void ResetEffects() 
    {
        CRTCameraBehaviour_scr.data.pixelationAmount = 0;
        CRTCameraBehaviour_scr.data.vignette = 0.112f;
        CRTCameraBehaviour_scr.data.dithering4 = 0;
    }

    public void ActivateEffect(int number)//set to new value when starting and reset to old value at end
    {
        isEffectActive = true;
        effectNumber = number;
        //SET EFFECT NUMBER HERE?
    }
}
