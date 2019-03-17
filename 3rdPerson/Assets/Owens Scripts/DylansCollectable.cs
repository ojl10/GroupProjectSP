using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DylansCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag == "Player")
        {
            IAddScore addscores = other.GetComponent<IAddScore>();
            addscores.addScoreDylan();
            Destroy(gameObject);
        }
           
    }            
}
