using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipCollide : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    private int clipSounded;
    //private CircleCollider2D circleCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        //circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    public void playClip()
    {

        if(clipSounded == 0)
        {
            audioSource.PlayOneShot(audioClip);
            clipSounded = 1;
        }

    }
}
