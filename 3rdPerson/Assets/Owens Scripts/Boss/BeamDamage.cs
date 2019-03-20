using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDamage : MonoBehaviour
{
    public bool autoDelete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (autoDelete)
        {
            Destroy(this, 0.5f);
        }
    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            target.GetComponent<Health>().Damage(1, target.transform.position);
        }
        
    }
}
