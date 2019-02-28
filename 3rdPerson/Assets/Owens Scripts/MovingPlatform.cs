using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    GameObject Player;
    public GameObject Platform;
    public Transform Point1;
    public Transform Point2;
    public Vector3 MovingTo;
    public float smooth;
    public float timeToWait = 3f;
    bool isActive;
    public string State;

    void Start()
    {
        changeDirection();
    }
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, MovingTo, smooth * Time.deltaTime);
    }

    void changeDirection()
    {
        if (State == "go to Position 1")
        {
            State = "go to Position 2";
            MovingTo = Point2.position;
        }
        else if (State == "go to Position 2")
        {
            State = "go to Position 1";
            MovingTo = Point1.position;
        }
        else if (State == "")
        {
            State = "go to Position 2";
            MovingTo = Point2.position;
        }
        Invoke("changeDirection", timeToWait);
    }


    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = Platform.transform;
    }
    private void OnTriggerExit(Collider other)
    {              
            other.transform.parent = null;       
    }
}
