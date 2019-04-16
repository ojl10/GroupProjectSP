using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoe_attack : MonoBehaviour
{
    public GameObject aoeObject;

    public GameObject effect;

    public float delay = 5f;

    public float lifetime = 1f;

    float uptime;

    float cooldown;

    bool canhit;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = delay;

        aoeObject.SetActive(false);

        uptime = lifetime;

        canhit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((canhit == true) && (Input.GetKeyDown(KeyCode.Q)))
        {
            aoeObject.SetActive(true);
            Debug.Log("has hit");
        }

        if (aoeObject.activeInHierarchy == true)
        {
            uptime -= Time.deltaTime;
        }

        if (uptime <= 0f)
        {
            aoeObject.SetActive(false);
            uptime = lifetime;
            canhit = false;
        }

        if ((uptime == 1f) && (canhit ==false))
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown <= 0f)
        {
            canhit = true;
            cooldown = delay;
        }
    }
}
