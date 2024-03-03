using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{

    public int remain = 4;
    void Update()
    {
        if (remain<=0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
