using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractObj : MonoBehaviour, Iinteract
{
    MeshRenderer myMesh;
    Collider mCollider;

    //Need to add ability to swap if object disapears or appears
    //add a timer potentially

    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        mCollider = GetComponent<Collider>();
        myMesh.enabled = false;
        mCollider.enabled = false;
    }

    public void Interacted()
    {
        myMesh.enabled = true;
        mCollider.enabled = true;
    }


}
