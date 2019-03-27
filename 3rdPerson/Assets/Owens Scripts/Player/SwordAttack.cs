using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : AbstractBehaviour
{
    [SerializeField]
    GameObject enemy = null;


    public AudioClip Swordhit;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }   

    private void OnTriggerEnter(Collider other)
{
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;

            if (enemy != null && enemy.gameObject.GetComponent(typeof(TakeDamager))) // if it is an enemy, and has the takedamager interface on it then do following
            {
                TakeDamager addscores = enemy.gameObject.GetComponent<TakeDamager>(); //if component that touches enemies, call the interface and damage
                addscores.ITakeDamage(1);
                audioSource.PlayOneShot(Swordhit, 0.7F);//audio here
                this.enabled = false;
            }
            else
            {

                //not enemy audio
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
 //
    }
}
