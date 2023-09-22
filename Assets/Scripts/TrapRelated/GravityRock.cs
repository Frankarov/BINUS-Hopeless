using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRock : MonoBehaviour
{

    public float gravity = -5.5f;
    public float maxFallSpeed = -10f;
    //trap's Y pos
    public float groundY = 0f;
    public Transform bucketTransform;
    public GameObject bucket;

    //audio
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    private int bucketSounded ;
    private int rockSounded;

    private Vector3 velocity = Vector3.zero;
    private bool isTouchGround = false;
    private Vector2 bucketFirstPosition;

    private void Start()
    {
        bucketFirstPosition = bucketTransform.position;
    }


    void FixedUpdate()
    {
        ApplyGravity();
        Move();
        TouchGround();
    }

    void ApplyGravity()
    {
        if (!isTouchGround)
        {
            velocity.y += gravity * Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y, maxFallSpeed, Mathf.Infinity);

            if (rockSounded == 0)
            {
                audioSource2.PlayOneShot(audioClip2);
                rockSounded = 1;

            }


        }
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void TouchGround()
    {

        BoxCollider2D collider = bucket.GetComponent<BoxCollider2D>();

        if (transform.position.y <= groundY)
        {
            //Debug.Log("UdahSentuhTanah");
            isTouchGround = true;
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
            //gameObject.SetActive(false);
            //bucketTransform.position = bucketFirstPosition;
            //this.enabled = false;
            if(collider !=null)
            {
            collider.enabled = false;
            }

            
            if(bucketSounded == 0)
            {
            audioSource.PlayOneShot(audioClip);
            bucketSounded = 1;

            }


        }
    }

}



