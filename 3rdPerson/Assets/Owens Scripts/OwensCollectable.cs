using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwensCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IAddScore addscores = other.GetComponent<IAddScore>();
        if (addscores != null)
        {
             //if component that touches collectables has the IAddScore component, call the interface
            addscores.addScoreOwen();
            Destroy(gameObject);
        }
                 
    }
}
