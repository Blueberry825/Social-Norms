using UnityEngine;

public class DontDestroy_Script : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
