using UnityEngine;

public class MenuStuff : MonoBehaviour
{
    public void HideObj(GameObject Obj)
    {
        Obj.SetActive(false);
    }

    public void ShowObj(GameObject Obj)
    {
        Obj.SetActive(true);
    }
}
