using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFX : MonoBehaviour
{
    [SerializeField] private float expandSpeed = .5f;
    void Start()
    {
        
    }
    void Update()
    {
        if (transform.localScale.x <= new Vector3(.6f,.6f,.6f).x)
        {
            transform.localScale += new Vector3(expandSpeed,expandSpeed,expandSpeed) * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("Hit");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Hit");
        }        
    }
}
