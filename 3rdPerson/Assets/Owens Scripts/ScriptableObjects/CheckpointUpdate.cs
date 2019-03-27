using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    //Owens Script. Changes the scriptable object values to the checkpoint the character has touched values. By splitting the X Y Z.
    public PosScriptable checkpointlocation; //scriptable object for saving data after closing game

    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    { if (transform.position.x != checkpointlocation.X && transform.position.z != checkpointlocation.Z)
        {
            checkpointlocation.X = transform.position.x;
            checkpointlocation.Y = transform.position.y;
            checkpointlocation.Z = transform.position.z;
            audioSource.PlayOneShot(impact, 0.6F);
        }
    else
        {

        }
        
    }
}
