using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Team()
    {
        SceneManager.LoadScene("Team");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
