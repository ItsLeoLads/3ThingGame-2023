using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//I got this code from https://www.youtube.com/watch?v=DX7HyN7oJjE 

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level0");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
