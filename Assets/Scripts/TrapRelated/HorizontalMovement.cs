using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalMovement : MonoBehaviour
{


    public float t = 0.0f;
    public float distance, speed, timeStart;
    private float originalPosX;
    //bool isRotate = false;

    void Start()
    {
        originalPosX = transform.position.x;

    }

    float a;

    void Update()
    {
        transform.position = new Vector3(originalPosX + Mathf.Sin(t) * distance, transform.position.y, transform.position.z);
        t += speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ocexit yes");

            collision.transform.SetParent(null);
        }
    }


}
