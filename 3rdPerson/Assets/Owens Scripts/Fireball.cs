using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject FireBall;
    float TimeTillFire;
    float ReloadTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        { 
            GameObject laser = Instantiate(FireBall,
            SpawnPosition.transform.position, SpawnPosition.transform.rotation) as GameObject;
            laser.GetComponent<Rigidbody>().velocity = SpawnPosition.transform.forward * 15;
        }
    }
}
