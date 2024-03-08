using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;
    private GameObject currentTarget;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            currentTarget = FindNearestEnemy();
            Shoot();
        }
    }

    void Shoot()
    {
        
        GameObject nearestEnemy = FindNearestEnemy();
        if (currentTarget != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().SetTarget(currentTarget.transform);
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                nearest = enemy;
            }
        }
        return nearest;
    }
}
