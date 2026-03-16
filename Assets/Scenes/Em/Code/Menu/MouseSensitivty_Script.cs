using TMPro;
using UnityEngine;

public class MouseSensitivty_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mouseSensitivity_TXT;


    public void MouseSensitvityChanged(float newMouseSensitivity) 
    {
        //change mouse
        newMouseSensitivity = Mathf.RoundToInt(newMouseSensitivity * 10);
        mouseSensitivity_TXT.text = newMouseSensitivity.ToString("F0");
    }
}
