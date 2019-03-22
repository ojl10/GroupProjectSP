using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnTouch : MonoBehaviour
{
    public int damageTaken; // How much damage to apply to the players scriptable object Health
    public intScriptable playerHealth; //Players Health stored as a scriptable object
    private void OnCollisionEnter(Collision collision) // When colliding with the obj, apply damage
    {
        playerHealth.Value = playerHealth.Value - damageTaken;
        
    }
}
