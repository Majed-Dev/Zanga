using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class officer : MonoBehaviour
{
    [SerializeField]private Transform playerPos;
    bool facingRight = true;
    [SerializeField] private float movementSpeed = .1f;
    [SerializeField] private float range = 1f;
    private bool inRange = true;
    private Animator anim;
    [SerializeField] Transform shootingPoint;
    public bool shooting = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        Range();
    }
    void Chase()
    {
        if(inRange)
        {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, movementSpeed * Time.deltaTime);
            anim.SetBool("isRunning", true);
            transform.LookAt(playerPos.position);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (transform.position.x > playerPos.transform.position.x && facingRight)
        {
            Flip();
        }
        else if (transform.position.x < playerPos.transform.position.x && !facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
            facingRight = !facingRight;
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 180, 0, 0), 20 * Time.deltaTime);
    }
    void Range()
    {
        if(Vector3.Distance(playerPos.position,transform.position) <= range)
        {
            inRange = false;
        }
        else
        {
            inRange = true;
        }
    }
    public void Shoot()
    {
        GameObject.Find("shootPoint").GetComponent<Collider>().enabled = true;
    }
    public void noShoot()
    {
        GameObject.Find("shootPoint").GetComponent<Collider>().enabled = false;
    }


}
