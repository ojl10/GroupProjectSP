using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : AbstractBehaviour
{
    [SerializeField]
    GameObject enemy = null;
    EnemyAI EAI;

    public AudioClip AOEhit;
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
                addscores.ITakeDamage(4);
                
                if (enemy.gameObject.GetComponent<EnemyAI>())
                {
                    EAI = enemy.gameObject.GetComponent<EnemyAI>();
                    EAI.TakenHit();
                }
                audioSource.PlayOneShot(AOEhit, 0.7F);
            }
            else
            {

                //not enemy audio
            }
        }
    }

 

    private void OnTriggerExit(Collider other)
    {
        enemy = null;
    }
}
