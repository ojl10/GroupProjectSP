using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    //Future ideas
    //Two Particle effects for hitting a collision, one for hitting an Enemy and one for anything else hit
    //Two diffrent sound effects for each
    //ammo/cool down time or both

    public float BulletLife;
    public ParticleSystem EnemyHit;
    public ParticleSystem NonEnemyHit;

    // Update is called once per frame
    void Update()
    {
        BulletLife -= Time.deltaTime;
        if (BulletLife <= 0) 

        {
            NonEnemyHit.Play();
            Destroy(this.gameObject, 0.3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent(typeof(TakeDamager)))
        {
            TakeDamager addscores = collision.gameObject.GetComponent<TakeDamager>(); //if component that touches collectables has the IAddScore component, call the interface
            addscores.ITakeDamage(1);
            EnemyHit.Play();
            Destroy(this.gameObject, 0.3f);
        }
        else
        {
            NonEnemyHit.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
