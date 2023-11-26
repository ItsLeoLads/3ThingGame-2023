using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plank : MonoBehaviour
{
    public bool hasFallen;

    [SerializeField] GameObject horizontalPlank;
    [SerializeField] GameObject verticalPlank;

    public void PushPlank()
    {
        if (!hasFallen)
        {
            hasFallen = true;
            horizontalPlank.SetActive(true);
            verticalPlank.SetActive(false);
        }
    }

}
