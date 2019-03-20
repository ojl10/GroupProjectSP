using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : AbstractBehaviour
{
    
    public Transform target;
    [SerializeField]
    float SlamCoolDown = 5f;
    [SerializeField]
    float Timer;
    public Animator Boss;
    [SerializeField]
    int AttackCount;
    [Range(1,3), SerializeField]
    int Rand;

    public float dist;

    bool canAttack;
    public Transform thisTransform;
    public ParticleSystem SlamPrt;
    public BossState curBossState;

    // Start is called before the first frame update
    void Start()
    { 
        Rand = 0;
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
       

        if (target != null && Timer > 0)
        {
            // transform.LookAt(target);
            Timer -= Time.deltaTime;
            if (curBossState != BossState.Exposed)
            {
                //thisTransform.LookAt(new Vector3(target.position.x, thisTransform.position.y, target.position.z));
                Vector3 dir = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(thisTransform.rotation, lookRotation, Time.deltaTime * 5).eulerAngles;
                thisTransform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }
        else if (target != null && Timer <= 0)
        {
            dist = Vector3.Distance(target.position, transform.position);
            canAttack = true;
            Rand = Random.Range(1, 4);
            if (Rand == 1 && AttackCount <= 3)
            {     
                AttackCount++;
                curBossState = BossState.Slam;
                BossStateSwitch();
            }
            else if (dist <= 16)
            {      
                AttackCount++;
                curBossState = BossState.Swipe;
                BossStateSwitch();
            }
            else if (Rand == 3 && AttackCount <= 3)
            {
                AttackCount++;
                curBossState = BossState.Beam;
                BossStateSwitch();
            }
            else if (AttackCount >= 4)
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
                    Debug.Log("Slam");
                SlamCoolDown = 3f;
                Timer = SlamCoolDown;
                    canAttack = false;        
                break;
            case BossState.Swipe:
                if (target != null && canAttack)                     
                    Boss.SetTrigger("Swipe");
                    Debug.Log("Swipe");
                    SlamCoolDown = 2.5f;
                    Timer = SlamCoolDown;
                    canAttack = false;
          
                break;
            case BossState.Beam:
                if (target != null && canAttack)
                    Boss.SetTrigger("Beam");
                    Debug.Log("Beam");
                    SlamCoolDown = 3f;
                    Timer = SlamCoolDown;
                    canAttack = false;
                break;
            case BossState.Exposed:
                if (AttackCount >= 4 )
                    Boss.SetTrigger("Exposed");  
                    Debug.Log("Exposed");
                    canAttack = false;
                    SlamCoolDown = 7.5f;
                    Timer = SlamCoolDown;
                    AttackCount = 0;
                break;
            case BossState.Dead:
                break;
        }
    }
    private void OnTriggerStay(Collider other)
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
