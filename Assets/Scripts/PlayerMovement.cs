using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Power Variables---------
    [SerializeField] private float rotationSpeed = 1f;
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

    SoundManager sm;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
        transform.right = Vector3.Slerp(transform.right, new Vector3(movementX, 0, 0), Time.deltaTime * rotationSpeed);

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
            sm.PlaySFX(sm.dash);
            anim.SetTrigger("isDashing");
            lastDash = Time.time;
            rb.AddForce(new Vector3(movementX * dashForce, 0f, movementZ * dashForce),ForceMode.Impulse);
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Quaternion targetRoation = new Quaternion(0, 180, 0, 0);
        if (facingRight)
        {
        transform.rotation = Quaternion.Lerp(transform.rotation,new Quaternion(0,180,0,0),20 * Time.deltaTime);

        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0,0, 0, 0), 20 * Time.deltaTime);
        }
        /*transform.Rotate(Vector3.Lerp(Vector3.zero,new Vector3(0,180,0),2));*/
        
    }
    public void Shrink()
    {

    }
}
