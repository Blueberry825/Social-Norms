using TMPro;
using UnityEngine;

public class MouseSensitivty_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mouseSensitivity_TXT;
    private string lastNum;
    private string currentNum;

    public void MouseSensitvityChanged(float newMouseSensitivity) 
    {
        //change mouse
        newMouseSensitivity = Mathf.RoundToInt(newMouseSensitivity * 10);
        mouseSensitivity_TXT.text = newMouseSensitivity.ToString("F0");
        if (mouseSensitivity_TXT.text == "0"|| mouseSensitivity_TXT.text == "1" || mouseSensitivity_TXT.text == "2" || mouseSensitivity_TXT.text == "3" || mouseSensitivity_TXT.text == "4" || mouseSensitivity_TXT.text == "5" || mouseSensitivity_TXT.text == "6" || mouseSensitivity_TXT.text == "7" || mouseSensitivity_TXT.text == "8" || mouseSensitivity_TXT.text == "9" || mouseSensitivity_TXT.text == "10") 
        {
            currentNum = mouseSensitivity_TXT.text.ToString();

            if (currentNum != lastNum) 
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Click_Low");
            }

            lastNum = currentNum;

        }
    }
}
