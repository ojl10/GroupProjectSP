using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject DestroyThis;
    public GameObject Player;
    public Transform Point;
    public GameObject Explosion;
    bool Active = false;
    bool Fired = true;
    public AudioClip Noise;

    private AudioSource speaker;
    void Start()
    {
        speaker = this.gameObject.AddComponent<AudioSource>();
    }


    void Update()
    {

        {
            //spawn explosion
            // helpful beginers instantiate guide at https://www.youtube.com/watch?v=4rZAAHevq1s
            if (Input.GetKeyDown("f") && Active && Fired)
                Instantiate(Explosion, Point.position, Point.rotation);
            // destroys chossen object
            if (Input.GetKeyDown("f") && Active && Fired)
                Destroy(DestroyThis);
            // plays explosion sound
            if (Input.GetKeyDown("f") && Active && Fired)
                speaker.PlayOneShot(Noise);
            // stops player from reusing the cannon
            if (Input.GetKeyDown("f") && Active && Fired)
                Fired = false;



        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Active = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Active = false;
    
    }
}


            


           