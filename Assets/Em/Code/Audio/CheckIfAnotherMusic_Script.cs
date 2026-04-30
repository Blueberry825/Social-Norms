using UnityEngine;

public class CheckIfAnotherMusic_Script : MonoBehaviour
{
    [SerializeField] private GameObject[] music_l;
    [SerializeField] private GameObject[] ambi_l;

    private void Start()
    {
        music_l = GameObject.FindGameObjectsWithTag("music_tag");

        if (music_l != null) //if there is an alien list
        {
            int musicListLength = music_l.Length;

            if (musicListLength > 1) //if theres more than one alien list
            {
                BackgroundMusic_Script bgm = music_l[1].GetComponent<BackgroundMusic_Script>();
                bgm.StopBackgroundMusic();
                Destroy(music_l[1]);

                //CLEAR LIST 
            }
        }

        ambi_l = GameObject.FindGameObjectsWithTag("ambi_tag");

        if (ambi_l != null) //if there is an alien list
        {
            int ambiListLength = ambi_l.Length;

            if (ambiListLength > 1) //if theres more than one alien list
            {
                Ambience_Script ambi = ambi_l[1].GetComponent<Ambience_Script>();
                ambi.stopAmbience();
                Destroy(ambi_l[1]);


                //CLEAR LIST 
            }
        }
    }
}
