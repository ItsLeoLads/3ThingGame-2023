using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneManager : MonoBehaviour
{

    public GameObject cutsceneTrigger;
    public GameObject mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cutsceneTrigger.SetActive(true);
        mainCamera.SetActive(false);
    }
}
