using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Transform ambienceDark;
    private float yyInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #region AnimationHandler
    private Animator animator;
    private void PlayWalk()
    {
        animator.SetTrigger("goWalk");
    }
    private void PlayJump()
    {
        animator.SetTrigger("goJump");
    }
    #endregion

    private void SpriteFlip(float yInput)
    {
        if(yInput < 0)
        {
            spriteRenderer.flipX = false;
            ambienceDark.position = transform.position + new Vector3(-1.39f, 1f, 0f);

        }
        else
        {
            spriteRenderer.flipX = true;
            ambienceDark.position = transform.position + new Vector3(1.39f, 1f, 0f);

        }
    }

    private void FixedUpdate()
    {
        float yInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(yInput*speed*Time.deltaTime,0f,0f));


        if(yInput != 0)
        {
            PlayWalk();
            yyInput = yInput;
        }
        else
        {
            animator.ResetTrigger("goWalk");
            //PlayWalk();
        }

        SpriteFlip(yyInput);

 

    }
    private void Update()
    {
          if(Input.GetKeyDown(KeyCode.Space)&& Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            
            rb.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            PlayJump();
        }
    }








} //end public class
