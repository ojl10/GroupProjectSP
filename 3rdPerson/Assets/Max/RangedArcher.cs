using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedArcher : MonoBehaviour
{
//Variables and Attributes for script

    private Transform target;

    [Header("Attributes")]

    public float range = 20f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    [Header("Unity Set-up Values")]

    public string playerTag = "Player";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject projectilePrefab;
    public Transform firePoint;


// Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
//Find the target or player
    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        foreach(GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }
//sets player as target
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
//if player isn't in range, then deselect target
        else
        {
            target = null;
        }
    }

// Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
//Target lock-on or Target Tracking
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 roatation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, roatation.y, 0f);

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        ArrowProjectile projectile = bulletGO.GetComponent<ArrowProjectile>();

        if (projectile != null)
            projectile.Seek(target);
    }
    //Range Display
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
