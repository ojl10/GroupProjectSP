using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            target.GetComponent<Health>().Damage(1, target.transform.position);
        }
        
    }
}
