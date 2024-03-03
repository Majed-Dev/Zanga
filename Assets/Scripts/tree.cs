using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tree : MonoBehaviour
{
    public int health = 5;
    SpriteRenderer sp;
    [SerializeField]Sprite[] hp = new Sprite[5];
    void Start()
    {
        sp = GameObject.Find("hp").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        switch(health)
        {
            case 5: sp.sprite = hp[5]; break;
            case 4: sp.sprite = hp[4]; break;
            case 3: sp.sprite = hp[3]; break;
            case 2: sp.sprite = hp[2]; break;
            case 1: sp.sprite = hp[1]; break;
            case 0: sp.sprite = hp[0]; break;
        }
        GameObject.Find("hp").transform.LookAt(GameObject.Find("Guardian").transform);
    }
}
