using UnityEngine;

public class AlienAnimationReset : MonoBehaviour
{
    public void ResetAnimationPlace()
    {
        this.GetComponent<Animator>().SetInteger("Mood", 4);
    }
}
