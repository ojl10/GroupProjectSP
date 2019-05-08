using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyprop : MonoBehaviour
{
   public GameObject DestroyThis;
   public GameObject Player;
    bool zone = false;
    void Update()
    {
       

            {

            if (Input.GetMouseButtonDown(0) && zone)
            Destroy(DestroyThis);
                    


               

            }
        }

    private void OnTriggerEnter(Collider other)
    {
        zone = true;
    }
    private void OnTriggerExit(Collider other)
    {
        zone = false;


    }
}