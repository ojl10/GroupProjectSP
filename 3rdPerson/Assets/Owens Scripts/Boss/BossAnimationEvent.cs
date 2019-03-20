using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvent : BossLookAt
{
    [SerializeField]
    GameObject weakPoint;
    [SerializeField]
    GameObject beamObject;
    [SerializeField]
    GameObject swipeObject;

    public GameObject HandSlamPos;
    public GameObject HandSlamParticle;

    // Start is called before the first frame update
    void Start()
    {
        swipeObject.SetActive(false);
        beamObject.SetActive(false);
        weakPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SlamFloor() //animation event
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
