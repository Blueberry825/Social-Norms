using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_Script : MonoBehaviour
{
    private TabletAppearDissapear_Script tabletScript;
    private void Start()
    {
        tabletScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
    }
    public void LoadDate() 
    {
        SceneManager.LoadScene("Date_Scene");
    }

    public void SwapTabletVisability_() 
    { 
        tabletScript.SwapMapVisibility();
        tabletScript.SwapTabletVisibility();
    }
}
