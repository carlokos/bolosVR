using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectBolo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pin"))
        {
            GameManager.instance.hasFall();
        }
    }
}
