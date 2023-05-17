using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class textLookingatCamera : MonoBehaviour
{
    private Camera lookAtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        lookAtPlayer = Camera.main;
    }

    private void LateUpdate()
    {
        transform.rotation = lookAtPlayer.transform.rotation;
    }
}
