using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetTree;
    [SerializeField] private float movementSpeed = .1f;
    [SerializeField] private float attackRange = .5f;
    Animator anim;
    bool facingRight = true;

    //Boolean Phases
    private bool isAttacking = false;
    void Start()
    {
        targetTree = GameObject.FindGameObjectWithTag("Tree").GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        chaseTree();
        Attacking();
        anim.SetBool("isAttacking", isAttacking);
    }
    private void chaseTree()
    {
        if(!isAttacking)
        transform.position= Vector3.MoveTowards(transform.position,targetTree.transform.position,movementSpeed * Time.deltaTime);

        if (transform.position.x > targetTree.transform.position.x && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }
    private void Attacking()
    {
        if(Vector3.Distance(transform.position,targetTree.transform.position) <= attackRange)
        {
            isAttacking = true;

        }
        else
        {
            isAttacking = false;
        }
    }
}
