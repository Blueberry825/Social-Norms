using UnityEngine;
using UnityEngine.Video;

public class IdleTimer : MonoBehaviour
{
    public int IdleTimeSetting;
    float LastIdleTime;
    private VideoPlayer demoClip;

    void Awake()
    {
        demoClip = GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        demoClip.url = "file://D:/Rio Stuff/Year3/Collab game/GAMES REPUBLIC VERSION/Social Norm Gameplay.mp4";
        demoClip.gameObject.SetActive(false);
        LastIdleTime = Time.time;
    }

    private void Update()
    {
        if (Input.anyKey || (Input.GetAxis("Mouse Y") != 0) || (Input.GetAxis("Mouse X") != 0))
        {
            LastIdleTime = Time.time;
            print("player not idle");
            demoClip.Stop();
            demoClip.gameObject.SetActive(false);
        }

        if (IdleCheck())
        {
            demoClip.gameObject.SetActive(true);
            demoClip.Play();
        }
    }

    public bool IdleCheck()
    {
        return Time.time - LastIdleTime > IdleTimeSetting;
    }
}
