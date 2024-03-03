using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Axe : MonoBehaviour
{
    Transform targetTree;
    [SerializeField] private float movementSpeed = .1f;
    [SerializeField] private float attackRange = .5f;
    Animator anim;
    bool facingRight = true;

    //Boolean Phases
    private bool inRange = false;
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
        anim.SetBool("inRange", inRange);
    }
    private void chaseTree()
    {
        if(!inRange)
        transform.position= Vector3.MoveTowards(transform.position,targetTree.transform.position,movementSpeed * Time.deltaTime);

        if (transform.position.x > targetTree.transform.position.x && facingRight)
        {
            Flip();
        }
        else if(transform.position.x < targetTree.transform.position.x && !facingRight)
        {
            Flip();
        }
    }
    private void Attacking()
    {
        if(Vector3.Distance(transform.position,targetTree.transform.position) <= attackRange)
        {
            inRange = true;

        }
        else
        {
            inRange = false;
        }
    }
    public void Hit()
    {
        GameObject.FindGameObjectWithTag("Tree").GetComponent<tree>().health--;
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
