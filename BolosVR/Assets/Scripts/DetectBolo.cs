using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectBolo : MonoBehaviour
{
    [SerializeField] private Transform[] pins;
    [SerializeField] private TextMeshProUGUI txtFallen;
    private float threshHold = 0.3f;
    private int fallen;

    private void hasFall()
    {
        foreach(Transform pin in pins)
        {
            
            if (pin.up.y < threshHold && !pin.GetComponent<pinBehaviour>().hasFall)
            {
                pin.GetComponent<pinBehaviour>().hasFall = true;
                pin.gameObject.SetActive(false);
                fallen++;
                txtFallen.text = fallen.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pin"))
        {
            hasFall();
        }
    }
}
