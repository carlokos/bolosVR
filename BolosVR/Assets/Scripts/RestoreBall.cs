using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreBall : MonoBehaviour
{
    [SerializeField] private Transform ballPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            other.gameObject.transform.position = ballPosition.position;
        }
    }
}
