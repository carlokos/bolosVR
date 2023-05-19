using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinBehaviour : MonoBehaviour
{
    public bool hasFall = false;
    private Transform defaultPosition;

    private void Start()
    {
        defaultPosition = gameObject.transform;
    }

    public void restorePin()
    {
        hasFall = false;
        gameObject.SetActive(true);
        transform.position = defaultPosition.position;
    }
}
