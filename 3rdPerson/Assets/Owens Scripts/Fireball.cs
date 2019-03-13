﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Camera MCam;
    public Transform SpawnPosition;
    public GameObject FireBall;

    public ParticleSystem Fire;

    public float TimeTillFire;
    public float ReloadTime = 0.3f;
    public bool canFire;


    void Update()
    {
        SpawnPosition.rotation = MCam.transform.rotation;
        if (Input.GetKeyDown("e") && canFire)
        {
            GameObject laser = Instantiate(FireBall,
            SpawnPosition.transform.position, SpawnPosition.transform.rotation);
            Fire.Play();
            laser.GetComponent<Rigidbody>().velocity = SpawnPosition.transform.forward * 15;
            TimeTillFire = ReloadTime;
            canFire = false;
        }
        else if (!canFire && TimeTillFire >= 0)
        {
            Fire.Pause();
            TimeTillFire -= Time.deltaTime;
        }
        if (TimeTillFire <= 0)
        {
            canFire = true;

        }

    }
}
