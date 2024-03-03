using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFX : MonoBehaviour
{
    [SerializeField] private float expandSpeed = .5f;
    SwitchLevel switchLevel;
    SoundManager sm;
    void Awake()
    {
        switchLevel = GameObject.Find("LevelSystem").GetComponent<SwitchLevel>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
        sm.PlaySFX(sm.attack);
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            switchLevel.remain--;
        }
    }
}
