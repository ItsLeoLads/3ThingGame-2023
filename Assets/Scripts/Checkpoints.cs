using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Checkpoints : MonoBehaviour
{    
    [SerializeField] private GameObject flagHit;
    [SerializeField] private GameObject flagNotHit;
    public Vector3 respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            flagHit.SetActive(true);
            flagNotHit.SetActive(false);
            respawnPoint = transform.position;
        }
    }
}
