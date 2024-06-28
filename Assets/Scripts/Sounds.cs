using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public static AudioClip shot, alert, lose;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        shot = Resources.Load<AudioClip>("break");
        alert = Resources.Load<AudioClip>("alert");
        lose = Resources.Load<AudioClip>("lose");

        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "break":
                audioSrc.PlayOneShot(shot);
                break;  
            case "alert":
                audioSrc.PlayOneShot(alert);
                break;   
            case "lose":
                audioSrc.PlayOneShot(lose);
                break;
        }
    }
}
 