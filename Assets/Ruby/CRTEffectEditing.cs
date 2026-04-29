using BrewedInk.CRT;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CRTEffectEditing : MonoBehaviour
{
    public bool isEffectActive;
    private bool titleSceneActive;

    private float effectTimer;
    private float timerDecreaseAmount = 2;
    private int frequency;

    private int effectNumber;

    private CRTCameraBehaviour CRTCameraBehaviour_scr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frequency = 30;
        effectTimer = 4;
        CRTCameraBehaviour_scr = GameObject.Find("Main Camera").GetComponent<CRTCameraBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEffectActive)
        {
            effectTimer -= timerDecreaseAmount * Time.deltaTime;
            print(effectTimer);

            var randInt = UnityEngine.Random.Range(0, frequency);//keep spawing new numbers every frame, if frame is certain number, trigger distortion effect to change

            if (randInt == 4)
            {
                print("1 in " + frequency + " chance");
                EffectChooser();
            }

            if (effectTimer <= 0)//if timer is over
            {
                isEffectActive = false;//stop effect
                ResetEffects();// reset crt
            }
        }

        if (titleSceneActive)
        {
            var randInt = UnityEngine.Random.Range(0, frequency);//keep spawing new numbers every frame, if frame is certain number, trigger distortion effect to change

            if (randInt == 4)
            {
                print("1 in " + frequency + " chance");
                TitleSceneEffects();
                Invoke("TitleSceneEffects", 0.05f);
                Invoke("ResetEffects", 0.3f);//wait and then reset?
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

              case 3:

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

    public void WaterDistortEffect()//set to new value when starting and reset to old value at end //effectNumber 2
    {
        CRTCameraBehaviour_scr.data.pixelationAmount = UnityEngine.Random.Range(0, 3);
        CRTCameraBehaviour_scr.data.vignette = UnityEngine.Random.Range(4f, 8f);
        CRTCameraBehaviour_scr.data.dithering4 = UnityEngine.Random.Range(0, 0);
    }

    public void TitleSceneEffects()//set to new value when starting and reset to old value at end //effectNumber 3
    {
        CRTCameraBehaviour_scr.data.colorScans.sizeMultiplier = UnityEngine.Random.Range(2.17f, 1.30f);
        CRTCameraBehaviour_scr.data.dithering4 = UnityEngine.Random.Range(0.01f, 0.05f);
        effectTimer = 1000;
        print("triggered");
    }

    public void ResetEffects() 
    {
        CRTCameraBehaviour_scr.data.pixelationAmount = 0;
        CRTCameraBehaviour_scr.data.vignette = 0.112f;
        CRTCameraBehaviour_scr.data.dithering4 = 0;
        CRTCameraBehaviour_scr.data.colorScans.sizeMultiplier = 2.17f;
    }

    public void ActivateEffect(int number)//set to new value when starting and reset to old value at end
    {
        effectTimer = 4;
        isEffectActive = true;
        effectNumber = number;
        //SET EFFECT NUMBER HERE?
    }

    public void ActivateTitleEffects()//set to new value when starting and reset to old value at end
    {
        frequency = 1200;
        titleSceneActive = true;
    }
}
