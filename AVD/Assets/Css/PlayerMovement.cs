/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    //Climb *

    //public float distance;
    //public LayerMask whatIsLadder;
    //float verticalMove = 0f;
    //private Rigidbody2D rb;
    //

    float horizontalMove = 0f;
    public float runSpeed = 10f;
    bool jump = false;
    bool crouch = false;
    bool climb = false;
    bool isClimbing;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        //Debug.Log(crouch);
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);

    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }


    // Coin

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }



    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        // CLIMB

        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        //if (hitInfo.collider != null)
        //{
        //    if (Input.GetButtonDown("Climb"))
        //  {
        //    isClimbing = true;
        //}
        //    } else 
        //  {
        //    if (Input.GetButtonDown("Horizontal"))
        //  {
        //       isClimbing = false;
        //  }
        //}

        //if (isClimbing == true && hitInfo.collider != null)
        //{
        //  verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        // rb.gravityScale = 0;
        // }
        //else 
        //{
        //   rb.gravityScale = 5;
        //}
        //

        jump = false;
    }
}*/
