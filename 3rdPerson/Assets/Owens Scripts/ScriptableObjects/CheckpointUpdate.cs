using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    public PosScriptable checkpointlocation;
    private void OnTriggerEnter(Collider other)
    {
        checkpointlocation.X = transform.position.x;
        checkpointlocation.Y = transform.position.y;
        checkpointlocation.Z = transform.position.z;
    }
}
