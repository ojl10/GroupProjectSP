using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEvent : MonoBehaviour
{
    public GameObject EndPos;
    public GameObject StartPos;
    public GameObject Lava;
    public intScriptable OwensBossHealth; //Has my boss been defeated
    public intScriptable PlayersHealthSO; //Players health
    public float RiseRate = 0.009f;
    bool lavaRising;//is the lava rising
    bool lavaRose; //could be used to detect when finished

    // Update is called once per frame
    void FixedUpdate()
    {
        if (OwensBossHealth.Value <= 0 && lavaRising)
        {
            Lava.transform.position = Vector3.Lerp(Lava.transform.position, EndPos.transform.position, Time.deltaTime * RiseRate);
        }
        if (PlayersHealthSO.Value <= 0 & !lavaRose)
        {
            
            ResetLavaRun();
        }
        
    }

    private void ResetLavaRun()
    {
        lavaRising = false;
        lavaRose = false;
        Lava.transform.position = StartPos.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        lavaRising = true;
    }
}
