using UnityEngine;

public class TextOnScreenNo_Script : MonoBehaviour
{
    private Animator Animator;

    private void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

    public void TextNo() 
    {
        Animator.SetBool("TextOnScreen", false);
    }
}
