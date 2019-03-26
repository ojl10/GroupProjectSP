using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : AbstractBehaviour
{
    [SerializeField]
    GameObject enemy = null;
    [SerializeField]
    float TimeTillFire;
    [SerializeField]
    float ReloadTime = 0.5f;
    [SerializeField]
    bool canFire;
    EnemyAI EAI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)//Plays the attack Anim
        {
            m_Animator.SetInteger("AttackNum",Random.Range(1,4));
            m_Animator.SetTrigger("PAttack");
            canFire = false;
            TimeTillFire = ReloadTime;

            if (enemy != null && enemy.gameObject.GetComponent(typeof(TakeDamager))) // if it is an enemy, and has the takedamager interface on it then do following
            {
                TakeDamager addscores = enemy.gameObject.GetComponent<TakeDamager>(); //if component that touches enemies, call the interface and damage
                addscores.ITakeDamage(1);
                if (enemy.gameObject.GetComponent<EnemyAI>())
                {
                    EAI = enemy.gameObject.GetComponent<EnemyAI>();
                    EAI.TakenHit(); 
                }
                //audio here
            }
            else
            {

                //not enemy audio
            }
        }
        else
        {
            //null
        }



         if (!canFire && TimeTillFire >= 0)
        {
            TimeTillFire -= Time.deltaTime;
        }
        if (TimeTillFire <= 0)
        {
            canFire = true;
        }

    }
    

    private void OnTriggerEnter(Collider other)
{
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        enemy = null;
    }
}
