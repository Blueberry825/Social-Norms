using UnityEngine;
using UnityEngine.UIElements;

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
        print("setting to: " + location + "," + scale);
    }

    public void alien0ResetScaleLocation()
    {
        transform.position = new Vector3(0, 1, 0);
        transform.localScale = new Vector3(55f, 55f);
    }
    public void alien2ResetScaleLocation()//not added
    {
        transform.position = new Vector3(0.15f, 0.18f, 0);
        transform.localScale = new Vector3(70f, 70f);
    }

    public void alien4ResetScaleLocation()//not added
    {
        transform.position = new Vector3(0.82f, 1.31f, 0);
        transform.localScale = new Vector3(80f, 80f);
    }

    public void alien5ResetScaleLocation()//not added
    {
        transform.position = new Vector3(-0.64f, 1.85f, 0);
        transform.localScale = new Vector3(75f, 75f);
    }

    public void alien9ResetScaleLocation()//not added
    {
        transform.position = new Vector3(0.18f, 1.08f, 0);
        transform.localScale = new Vector3(92f, 92f);
    }

    public void alien12ResetScaleLocation()//not added
    {
        transform.position = new Vector3(-2.41f, 0.17f, 0);
        transform.localScale = new Vector3(74f, 74f);
    }

    public void alien13ResetScaleLocation()//not added
    {
        transform.position = new Vector3(0f, 1.85f, 0);
        transform.localScale = new Vector3(62f, 62f);
    }

    public void alien14ResetScaleLocation()//not added
    {
        transform.position = new Vector3(0.15f, 1.11f, 0);
        transform.localScale = new Vector3(68f, 68f);
    }
}
