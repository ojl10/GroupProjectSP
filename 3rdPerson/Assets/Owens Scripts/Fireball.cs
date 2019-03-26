using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : AbstractBehaviour
{
    public Camera MCam;   
    public Transform SpawnPosition;
    public GameObject FireBall;

    public ParticleSystem Fire;

    public float TimeTillFire;
    public float ReloadTime = 0.5f;
    private bool canFire;

    private void Start()
    {
        MCam = FindObjectOfType<Camera>();
    }
    void Update()
    {
        SpawnPosition.rotation = MCam.transform.rotation;

        if (Input.GetKeyDown("e") && canFire)
        {
            m_Animator.SetTrigger("FireBall");
            canFire = false;
        }
        else if (!canFire && TimeTillFire >= 0)
        {
            Fire.Pause();
            TimeTillFire -= Time.deltaTime;
        }
        else if (TimeTillFire <= 0 & !canFire)
        {
            canFire = true;
        }
    }

    void Hit()
    {
        TimeTillFire = ReloadTime;
        GameObject laser = Instantiate(FireBall,
        SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        Fire.Play();
    }

}
