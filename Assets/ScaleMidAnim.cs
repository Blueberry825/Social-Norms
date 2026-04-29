using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class ScaleMidAnim : MonoBehaviour
{
    private Vector3 location;
    private Vector3 scale;

    public void SetFullScreen()
    {
        transform.localScale = new Vector3(100f, 100f);
        transform.position = new Vector3(0,0,0);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void GetNormalSize()
    {
        location = this.gameObject.transform.position;
        scale = this.gameObject.transform.localScale;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ReturnNormalSize()
    {
        transform.localScale = scale;
        transform.position = location;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
