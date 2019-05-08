using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobing : MonoBehaviour
{
    void Update()
    {
        

        // Move the object upward in world space 1 unit/second.
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }
}
