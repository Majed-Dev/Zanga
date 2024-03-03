using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackFX;
    [SerializeField] Transform attackPoint;
    SoundManager sm;

    [SerializeField] private float attackSpeed = .3f;
    private float lastAttack;
    void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack1();
    }
    void Attack1()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - lastAttack < attackSpeed)
            {
                return;
            }
            lastAttack = Time.time;
            Instantiate(attackFX, attackPoint, false);

        }
    }
}
