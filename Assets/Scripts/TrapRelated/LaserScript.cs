using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    public BoxCollider2D colliderLaser;
    public SpriteRenderer spriteLaser;
    public float LaserOffTime;

    void Start()
    {
        colliderLaser = GetComponent<BoxCollider2D>();
        
        spriteLaser = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        StartCoroutine(LaserOffFunc());
    //    }
    //}

    public void LaserOff()
    {

        StartCoroutine(LaserOffFunc());
    }

    private IEnumerator LaserOffFunc()
    {
        Debug.Log("laserofffunc bekerja");

        spriteLaser.enabled = false;
        colliderLaser.enabled = false;
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(LaserOffTime);
        spriteLaser.enabled = true;
        colliderLaser.enabled = true;
        audioSource.PlayOneShot(audioClip2);


    }

}
