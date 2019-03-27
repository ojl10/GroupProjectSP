using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnable : AbstractBehaviour
{

    [SerializeField]
    float TimeTillFire;
    [SerializeField]
    float ReloadTime = 0.5f;
    [SerializeField]
    bool canFire;
    public GameObject swordBox;

    void Start()
    {
        swordBox.SetActive(false);
    }   

        // Update is called once per frame
        void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)//Plays the attack Anim
        {
            swordBox.SetActive(true);
            m_Animator.SetInteger("AttackNum",Random.Range(1,4));
            m_Animator.SetTrigger("PAttack");
            canFire = false;
            TimeTillFire = ReloadTime;
            Invoke("SwordEnabled", 0.2f);  
        }
        else
        {
            //null
        }
         if (!canFire && TimeTillFire >= 0)
        {
            TimeTillFire -= Time.deltaTime;
        }
        if (TimeTillFire <= 0)
        {
            canFire = true;
        }

    }
    void SwordEnabled()
    {
        swordBox.SetActive(false);
    }
}
