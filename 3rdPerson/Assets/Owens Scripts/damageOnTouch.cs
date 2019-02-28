using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnTouch : MonoBehaviour
{
    public int damageTaken;
    public intScriptable playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerHealth.Value = playerHealth.Value - damageTaken;
        
    }
}
