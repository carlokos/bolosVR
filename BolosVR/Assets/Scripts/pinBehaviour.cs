using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinBehaviour : MonoBehaviour
{
    public bool hasFall = false;
    public Transform defaultPosition;

    private void Start()
    {
        defaultPosition.position = transform.position;
    }

    private void Update()
    {
        Debug.Log("UPy del bolo:" + transform.up.y.ToString());
    }

    public void restorePin()
    {
        hasFall = false;
        transform.position = defaultPosition.position;
    }
}
