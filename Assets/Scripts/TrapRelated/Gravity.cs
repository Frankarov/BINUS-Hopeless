using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravity = -5.5f;
    public float maxFallSpeed = -10f;
    //trap's Y pos
    public float groundY = 0f;
    public Transform bucketTransform;
    public GameObject bucket;

    //audio
    public AudioSource audioSource;
    public AudioClip audioClip;
    private int bucketSounded ;

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



