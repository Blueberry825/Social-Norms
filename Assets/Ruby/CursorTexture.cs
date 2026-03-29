using UnityEngine;

public class CursorTexture : MonoBehaviour
{
    public Texture2D cursorIdle;
    public Texture2D cursorPressed;
    [SerializeField]

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(cursorIdle, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorPressed, Vector2.zero, CursorMode.ForceSoftware);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorIdle, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}


