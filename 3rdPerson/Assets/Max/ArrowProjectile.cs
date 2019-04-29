using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    private Transform target;
//Variables and Attributes
    public float speed = 2f;
    public float lifeTime = 3f;

//Method for projectile attributes
    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "MAINCHAR")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = 30 * this.transform.forward;
        gameObject.transform.Rotate(0, 180, 0);


        {
            Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

         transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }
    void HitTarget()
    {
        Destroy(gameObject);
    }
}
