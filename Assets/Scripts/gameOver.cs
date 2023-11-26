using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    public void Start()
    {
        if(gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        Invoke("PauseGame", 1);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void restartButton()
    {
        SceneManager.LoadScene("level0");
        gameObject.SetActive(false);
        ResumeGame();
    }

    public void exitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
