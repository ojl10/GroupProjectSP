using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamager : MonoBehaviour, Damageable
{
    public intScriptable EnemyHealth;
    public EnemyHealth Ehealth;

    public void ITakeDamage(int damage)
    {
        if (EnemyHealth != null)
        {
            EnemyHealth.Value -= damage;
        }
        else if (Ehealth != null)    
        {
            Ehealth.currentHealth -= damage;
        }
        else
        {
            Debug.Log("Health object Null");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        if (EnemyHealth != null)
        {
            EnemyHealth.Value = EnemyHealth.MaxValue;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth != null && EnemyHealth.Value <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            
        }
    }
}

