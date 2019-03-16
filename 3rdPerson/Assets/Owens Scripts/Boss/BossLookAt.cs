using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : AbstractBehaviour
{
    [SerializeField]
    Transform target;
    public float SlamCoolDown = 5f;
    public float Timer;
    public Animator Boss;
    float rot;

    public ParticleSystem SlamPrt;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<Animator>();
    }

    private enum BossState
    {
        Idle,
        Slam,
        Swipe,
        Beam,
        Exposed,
        Dead
    }
    // Update is called once per frame
    void Update()
    {
        
        if (target != null && Timer > 0)
        {
            // transform.LookAt(target);
            Vector3 targetDir = target.position -= transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
          
            //transform.rotation = Quaternion.Euler(0,angle,0);
            Timer -= Time.deltaTime;
        }
        else if (target != null && Timer <= 0)
        {
            Boss.SetTrigger("Slam");
           Invoke("SlamATK", 0.2f);
            Timer = SlamCoolDown;
        }
        
    }


    void SlamATK()
    {
        SlamPrt.Play();
        target.GetComponent<Health>().Damage(1, target.position);  //transform.position   removed
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }
}
