using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : AbstractBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float SlamCoolDown = 5f;
    [SerializeField]
    float Timer;
    public Animator Boss;
    [SerializeField]
    int AttackCount;
    [SerializeField]
    int Rand;

    bool canAttack;

    public ParticleSystem SlamPrt;
    public BossState curBossState;

    // Start is called before the first frame update
    void Start()
    {
        AttackCount = 0;
        Boss = GetComponent<Animator>();
    }

     public enum BossState
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
        
        //Rand = Random.Range(1,3);

        if (target != null && Timer > 0)
        {
            // transform.LookAt(target);
            Timer -= Time.deltaTime;    
        }
        else if (target != null && Timer <= 0)
        {
            canAttack = true;
            //Cycle attacks here
            //curBossState = BossState.Slam;
            
            if (AttackCount == 1)
            {
                curBossState = BossState.Slam;
                BossStateSwitch();
            }
            else if (AttackCount == 2)
            {
                curBossState = BossState.Swipe;
                BossStateSwitch();
            }
            else if (AttackCount == 3)
            {
                curBossState = BossState.Beam;
                BossStateSwitch();
            }
            else
            {
                curBossState = BossState.Exposed;
                BossStateSwitch();
            }
        }
    }

    void BossStateSwitch()
    {
        switch (curBossState)
        {
            case BossState.Idle:
                if (!canAttack)
                {
                    curBossState = BossState.Idle;
                }
                break;
            case BossState.Slam:
                if (target != null && canAttack)
                    Boss.SetTrigger("Slam");
                    AttackCount++;
                    Debug.Log("Slam");
                    Timer = SlamCoolDown;
                    canAttack = false;
                 
                break;
            case BossState.Swipe:
                if (target != null && canAttack)           
           
                    Boss.SetTrigger("Swipe");
                    AttackCount++;
                    Debug.Log("Swipe");
                    Timer = SlamCoolDown;
                    canAttack = false;
          
                break;
            case BossState.Beam:
                if (target != null && canAttack)
              
                    Boss.SetTrigger("Beam");
                    AttackCount++;
                    Debug.Log("Beam");
                    Timer = SlamCoolDown;
                    canAttack = false;
               

                break;
            case BossState.Exposed:
                if (AttackCount >= 4 )
              
                    Boss.SetTrigger("Exposed");
                    AttackCount = 1;  
                    Debug.Log("Exposed");
                    Timer = SlamCoolDown;
                
                              
                break;
            case BossState.Dead:
                break;
        }
    }



    void SlamFloor() //animation event
    {
        SlamPrt.Play(); //instatiate object to deal damage, allows for another collider
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
