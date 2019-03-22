using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvent : BossLookAt
{
    [SerializeField]
    GameObject weakPoint; // Boss's damageable point
    [SerializeField]
    GameObject beamObject; //Chest beam
    [SerializeField]
    GameObject swipeObject; // Boss fore arm collider

    public GameObject HandSlamPos; // where to spawn the particle effects
    public GameObject HandSlamParticle;// particle effects that will damage the player

    // Start is called before the first frame update
    void Start() // Switch all the objects off untill needed
    {
        swipeObject.SetActive(false);
        beamObject.SetActive(false);
        weakPoint.SetActive(false);
    }

    void SlamFloor() //animation event that spawns the particle effects to damage the player
    {
        GameObject HandSlam = Instantiate(HandSlamParticle,
        HandSlamPos.transform.position, HandSlamPos.transform.rotation);

    }
    void SwipeStart()
    {
        swipeObject.SetActive(true);
    }
    void SwipeEnd()
    {
        swipeObject.SetActive(false);

    }
    void BeamStart()
    {
        beamObject.SetActive(true);
    }
    void BeamEnd()
    {
        beamObject.SetActive(false);
    }
    void ExposedStart()
    {
        weakPoint.SetActive(true);
    }
    void ExposedEnd()
    {
        weakPoint.SetActive(false);
    }
}
