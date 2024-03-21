using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject iceballPrefab;
    public Transform firePoint;
    private GameObject currentTarget;
    public float shootInterval = 1.2f;

    void Start()
    {
        InvokeRepeating("AutoShoot", 0f, shootInterval);
    }


    void AutoShoot()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            currentTarget = FindNearestEnemy();
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            StartCoroutine(ShootBullets(PlayerStatsManager.Instance.bulletsPerShoot, nearestEnemy));

            if (PlayerStatsManager.Instance.iceballCount > 1)
            {
                StartCoroutine(ShootIceballs(PlayerStatsManager.Instance.iceballCount, nearestEnemy));
            }
        }
    }

    IEnumerator ShootBullets(int bulletsToShoot, GameObject nearestEnemy)
    {
        
        for (int i = 0; i < bulletsToShoot; i++)
        {
            if (nearestEnemy == null || nearestEnemy.gameObject == null)
            {
                yield break;
            }
            FindObjectOfType<SoundManager>().PlaySoundEffect("Fire");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            Vector3 direction = nearestEnemy.transform.position - firePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().SetTarget(nearestEnemy.transform);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator ShootIceballs(int iceballsToShoot, GameObject nearestEnemy)
    {
        
        yield return new WaitForSeconds(PlayerStatsManager.Instance.bulletsPerShoot * 0.09f);

        for (int i = 0; i < iceballsToShoot; i++)
        {
            if (nearestEnemy == null)
                yield break;

            GameObject iceball = Instantiate(iceballPrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = nearestEnemy.transform.position - firePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            iceball.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

            if (iceball.GetComponent<Bullet>() != null)
            {
                iceball.GetComponent<Bullet>().SetTarget(nearestEnemy.transform);
            }

            yield return new WaitForSeconds(0.15f);
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
