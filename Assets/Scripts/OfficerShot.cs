using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OfficerShot : MonoBehaviour
{            officer officer;    
    void Start()
        {
            officer = GameObject.Find("officer").GetComponent<officer>();
        }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
