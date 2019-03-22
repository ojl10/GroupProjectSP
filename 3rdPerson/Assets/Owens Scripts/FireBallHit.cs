using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    //Future ideas
    //Two Particle effects for hitting a collision, one for hitting an Enemy and one for anything else hit
    //Two diffrent sound effects for each
    //ammo/cool down time or both

    public float BulletLife;            //Lifespan of the bullet
    public ParticleSystem EnemyHit;     //Enemy has been hit particle effect for visual feedback
    public ParticleSystem NonEnemyHit;  //When anything but a enemy has been hit play another particle effect
    public GameObject Player;           //The player

    public Transform Target;            //Targeting system

    Collider ThisCollider;

    // Update is called once per frame
    private void Start()
    {
        ThisCollider = GetComponent<Collider>();
        Target = null;
        GetComponent<Rigidbody>().velocity = this.transform.forward * 25;
    }

    void Update()
    {
        
        BulletLife -= Time.deltaTime;
        if (BulletLife <= 0) 

        {
            NonEnemyHit.Play();
            Destroy(this.gameObject, 0.3f);
        }
        if (Target != null)
        {
            transform.LookAt(Target);
            GetComponent<Rigidbody>().velocity = this.transform.forward * 25;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.GetComponent(typeof(TakeDamager)))
        {
            EnemyHit.Play();
            TakeDamager addscores = collision.gameObject.GetComponent<TakeDamager>(); //if component that touches enemies, call the interface and damage     
            addscores.ITakeDamage(1);
            ThisCollider.enabled = !ThisCollider.enabled;
            Destroy(this.gameObject, 0.3f);
        }
        else if  (collision.gameObject.tag != "Player")
        {
            NonEnemyHit.Play();
            Destroy(gameObject, 0.3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            {
                Target = other.transform;
            }   
    }

}
