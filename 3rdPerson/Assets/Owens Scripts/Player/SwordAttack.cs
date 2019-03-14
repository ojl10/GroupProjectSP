using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : AbstractBehaviour
{
    public GameObject enemy;
    public float TimeTillFire;
    public float ReloadTime = 0.3f;
    public bool canFire;
    EnemyAI EAI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)//Plays the attack Anim
        {
            m_Animator.SetTrigger("PAttack");
            canFire = false;
            TimeTillFire = ReloadTime;

            if (enemy.gameObject.GetComponent(typeof(TakeDamager)))
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
                //not enemy
            }
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
