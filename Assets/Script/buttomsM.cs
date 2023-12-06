using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class buttomsM : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Play2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Play3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Options()
    {
        SceneManager.LoadScene("options");
        Time.timeScale = 1;
    }
}
