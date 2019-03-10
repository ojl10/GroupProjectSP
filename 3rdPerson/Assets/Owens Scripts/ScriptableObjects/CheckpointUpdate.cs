using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    //Owens Script. Changes the scriptable object values to the checkpoint the character has touched values. By splitting the X Y Z.
    public PosScriptable checkpointlocation; //scriptable object for saving data after closing game
    private void OnTriggerEnter(Collider other)
    {
        checkpointlocation.X = transform.position.x;
        checkpointlocation.Y = transform.position.y;
        checkpointlocation.Z = transform.position.z;
    }
}
