using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingObject : MonoBehaviour
{
    public GameObject EnerguPull_FX;
    public intScriptable playerHealth;
    bool InBox = false;
    bool active = true;

    // Update is called once per frame
    void Update()
    {
        if (InBox && active && Input.GetKeyDown("f"))
        {
            playerHealth.Value++;
            active = false;
        }   
        if (!active)
        {
            EnerguPull_FX.SetActive(false);
        }
        else if (active)
        {
            EnerguPull_FX.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InBox = true;
    }
    private void OnTriggerExit(Collider other)
    {
        InBox = false;
    }
}
