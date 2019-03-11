using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    public float BulletLife;

    // Update is called once per frame
    void Update()
    {
        BulletLife -= Time.deltaTime;
        if (BulletLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamager addscores = other.GetComponent<TakeDamager>(); //if component that touches collectables has the IAddScore component, call the interface
            addscores.ITakeDamage(1);
            Destroy(this.gameObject);
        }
        else
        {
          
        }
        
    }
}
