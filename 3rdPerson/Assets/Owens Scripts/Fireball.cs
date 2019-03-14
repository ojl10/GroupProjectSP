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
    public float ReloadTime = 0.3f;
    public bool canFire;

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

            Invoke ("FireBallAttack",0.1f);
            
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

    void FireBallAttack()
    {
        GameObject laser = Instantiate(FireBall,
            SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        Fire.Play();
        //laser.GetComponent<Rigidbody>().velocity = SpawnPosition.transform.forward * 15;
        TimeTillFire = ReloadTime;
        canFire = false;
    }
}
