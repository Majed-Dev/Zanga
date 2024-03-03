using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OfficerShot : MonoBehaviour
{            [SerializeField]officer officer;
    [SerializeField] SoundManager sm;
    void Start()
        {
        }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
