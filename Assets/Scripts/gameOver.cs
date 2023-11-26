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
    }

    public void restartButton()
    {
        SceneManager.LoadScene("level0");
        gameObject.SetActive(false);
    }

    public void exitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
