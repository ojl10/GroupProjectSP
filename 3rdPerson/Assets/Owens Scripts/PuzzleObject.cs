using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    public GameObject ActivatorObj;//object that will activate an event
    public GameObject ActivatedObj;//object that will be triggered

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuzzlePiece")
        {
            ActivatorObj = other.gameObject;
            Activated();
        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        ActivatorObj = null;
    }

    void Activated()
    {
        Iinteract interacting = ActivatedObj.gameObject.GetComponent<Iinteract>(); //calls a interaction on the activatable object.
        interacting.Interacted();
    }
}
