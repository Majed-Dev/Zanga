using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFX : MonoBehaviour
{
    [SerializeField] private float expandSpeed = .5f;
    SwitchLevel switchLevel;
    void Awake()
    {
        switchLevel = GameObject.Find("LevelSystem").GetComponent<SwitchLevel>();
    }
    void Update()
    {
        if (transform.localScale.x <= new Vector3(.3f,.3f,.3f).x)
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
            Destroy(other.gameObject);
            switchLevel.remain--;
        }
    }
}
