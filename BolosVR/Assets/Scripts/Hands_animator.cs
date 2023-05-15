using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands_animator : MonoBehaviour
{
    public List<UnityEngine.XR.InputDevice> gameControllers;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameControllers = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.RightHanded, gameControllers);
    }

    // Update is called once per frame
    void Update()
    {
        bool grabing = false;
        if(gameControllers.Count > 0)
        {
            if (gameControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grabing))
            {
                anim.SetBool("Grab", grabing);
            }
            else
            {
                anim.SetBool("Grab", grabing);
            }
        }
    }
}
