using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DylansCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {     
            IAddScore addscores = other.GetComponent<IAddScore>();
            addscores.addScoreDylan();
            Destroy(gameObject);
    }            
}
