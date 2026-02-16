using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;


public class LoveMeter : MonoBehaviour
{
    public Slider loveMeter;

    public float loveAmount = 100f;
    public float decayAmount;
    public float decayTime;
    public bool decaying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loveMeter.value = loveAmount;//set to default love amount

    }

    // Update is called once per frame
    void Update() // decrease love amount each frame
    {
        loveMeter.value = loveAmount;
        loveAmount -= decayAmount * Time.deltaTime;

        if (loveAmount > 100)
            loveAmount = 100;

        if (loveAmount <= 0)
        {
            Debug.Log("end level");
        }
    }

    public void LoveChange(int option)
    {
        switch(option)// optionID
        {
            case 0://love decrease
                loveAmount -= 15;
            break;

            case 1: //love neutral?

            break;

            case 2://love increase
                loveAmount += 15;
                break;

        }
    }
}
