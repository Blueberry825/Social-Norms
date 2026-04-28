using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
  public void DestroySelf()//put at end of gift anim
  {
        Destroy(this.gameObject);
  }


}
