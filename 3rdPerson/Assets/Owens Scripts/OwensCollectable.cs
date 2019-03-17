using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwensCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IAddScore addscores = other.GetComponent<IAddScore>();
            //if component that touches collectables has the IAddScore component, call the interface
            addscores.addScoreOwen();
            Destroy(gameObject);
        }                 
    }
}
