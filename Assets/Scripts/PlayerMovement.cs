using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Power Variables---------
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float dashForce = 3f;
    //Component Variables-----
    SpriteRenderer sr;
    Rigidbody rb;
    Animator anim;
    //Cooldown Variables-----
    [SerializeField] private float dashCooldown = .5f;
    private float lastDash;

    bool facingRight = true;

    float movementX;
    float movementZ;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Dash();
    }

    private void Movement()
    {
        
        movementX = Input.GetAxisRaw("Horizontal");
        movementZ = Input.GetAxisRaw("Vertical");

        //For Runing Animation
        if(movementX != 0 || movementZ != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //For Flipping the character
        if(movementX<0 && facingRight)
        {
            Flip();
        }
        else if(movementX>0 && !facingRight)
        {
            Flip();
        }

        transform.Translate(new Vector3(movementX,0f,movementZ).normalized * Time.deltaTime * movementSpeed,Space.World);
    }
    private void Dash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            if(Time.time - lastDash < dashCooldown)
            {
                return;
            }
            lastDash = Time.time;
            rb.AddForce(new Vector3(movementX * dashForce, 0f, movementZ * dashForce),ForceMode.Impulse);
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
        
    }
    public void Shrink()
    {

    }
}
