using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Camera MCam;
    public Transform SpawnPosition;
    public GameObject FireBall;
    float TimeTillFire;
    float ReloadTime;

    void Update()
    {
        SpawnPosition.rotation = MCam.transform.rotation;

        if (Input.GetKeyDown("e"))
        { 
            GameObject laser = Instantiate(FireBall,
            SpawnPosition.transform.position, SpawnPosition.transform.rotation);
            laser.GetComponent<Rigidbody>().velocity = SpawnPosition.transform.forward * 15;
        }
    }
}
