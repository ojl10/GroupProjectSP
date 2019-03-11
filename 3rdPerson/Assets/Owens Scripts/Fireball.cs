using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Camera MCam;
    public Transform SpawnPosition;
    public GameObject FireBall;
    public float TimeTillFire;
    public float ReloadTime;
    public bool canFire;

    void Update()
    {
        SpawnPosition.rotation = MCam.transform.rotation;

        if (Input.GetKeyDown("e") && canFire)
        { 
            GameObject laser = Instantiate(FireBall,
            SpawnPosition.transform.position, SpawnPosition.transform.rotation);
            laser.GetComponent<Rigidbody>().velocity = SpawnPosition.transform.forward * 15;
            TimeTillFire = ReloadTime;
            canFire = false;
        }
        else if (!canFire && TimeTillFire >= 0)
        {
            TimeTillFire -= Time.deltaTime;
        }
        if (TimeTillFire <= 0)
        {
            canFire = true;

        }
    }
}
