using TMPro;
using UnityEngine;

public class GetAlienName_Script : MonoBehaviour
{
    private TextMeshProUGUI alienName_TXT;

    private void Start()
    {
        alienName_TXT = GameObject.Find("AlienName_TXT").GetComponent<TextMeshProUGUI>();
    }

    public void setAlienName(string name) 
    { 
        alienName_TXT.text = name;
    }
}
