using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_Script : MonoBehaviour
{
    private TabletAppearDissapear_Script tabletScript;

    public void LoadDate() 
    {
        SceneManager.LoadScene("Date_Scene");
    }

    public void SwapTabletVisability_() 
    {
        tabletScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
        tabletScript.SwapMapVisibility();
        tabletScript.SwapTabletVisibility();
    }

    public void swapTablet2() 
    {
        tabletScript.SwapTabletVisibility();
        tabletScript.SwapMapVisibility();

    }

    public void LoadDatingAppScene() 
    {
        SceneManager.LoadScene("Title_Scene");
    }
}
