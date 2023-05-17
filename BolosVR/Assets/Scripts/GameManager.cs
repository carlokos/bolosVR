using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] pins;
    [SerializeField] private GameObject cvInfo;
    [SerializeField] private TextMeshProUGUI txtFallen;
    [SerializeField] private TextMeshProUGUI txtInfo;
    [SerializeField] private AudioSource strikeSound;
    [SerializeField] private AudioSource hitSound;
    public int tries;
    private float threshHold = 1f;
    private int fallen;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        tries = 2;
        cvInfo.SetActive(false);
    }
    

    public void hasFall()
    {
        foreach (Transform pin in pins)
        {
            if (pin.up.y < threshHold && !pin.GetComponent<pinBehaviour>().hasFall)
            {
                pin.GetComponent<pinBehaviour>().hasFall = true;
                hitSound.Play();
                fallen++;
                txtFallen.text = fallen.ToString();
            }
        }
    }

    public void quitFallenPins()
    {
        foreach(Transform pin in pins)
        {
            if (pin.GetComponent<pinBehaviour>().hasFall)
            {
                pin.gameObject.SetActive(false);
            }
        }
    }

    public void restTries()
    {
        tries -= 1;
    }

    private void Update()
    {
        if(tries <= 0)
        {
            //reiniciamos la escena y mostramos la puntuacion
            txtInfo.text = "Has conseguido derribar " + fallen.ToString() + " bolos, reiniciando la pista...";
            StartCoroutine(showInfo());
        }   

        if(fallen >= pins.Length)
        {
            txtInfo.text = "HAS HECHO UN PLENO, ENHORABUENA";
            strikeSound.Play();
            StartCoroutine(showInfo());
        }
    }

    private void restorePins()
    {
        tries = 2;
        fallen = 0;
        txtFallen.text = fallen.ToString();
        foreach (Transform pin in pins)
        {
            pin.GetComponent<pinBehaviour>().restorePin();
        }
    }

    private IEnumerator showInfo()
    {
        cvInfo.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        cvInfo.SetActive(false);
        restorePins();
    }
}
