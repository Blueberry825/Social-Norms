using TMPro;
using UnityEngine;

public class GetAlienName_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alienName_TXT;
    [SerializeField] private TextMeshProUGUI alienBio_TXT;

    private void Start()
    {
        alienName_TXT = GameObject.Find("AlienName_TXT").GetComponent<TextMeshProUGUI>();
        alienBio_TXT = GameObject.Find("AlienBio_TXT").GetComponent<TextMeshProUGUI>();
    }

    public void setAlienName(string name) 
    { 
        alienName_TXT.text = name;
    }

    public void setAlienBio(string name)
    {
        alienBio_TXT.text = name;
    }
}
