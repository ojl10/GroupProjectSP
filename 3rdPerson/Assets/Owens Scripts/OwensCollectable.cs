using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwensCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            IAddScore addscores = other.GetComponent<IAddScore>();
            addscores.addScoreOwen();
            Destroy(gameObject);        
    }
}
