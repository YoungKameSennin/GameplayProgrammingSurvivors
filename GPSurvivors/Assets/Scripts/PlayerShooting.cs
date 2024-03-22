using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject iceballPrefab;
    public GameObject APbulletPrefab;
    public Transform firePoint;
    private GameObject currentTarget;
    public float shootInterval = 1.2f;

    void Start()
    {
        InvokeRepeating("AutoShoot", 0f, shootInterval);
    }

    // Shoot at the nearest enemy.
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

            if (PlayerStatsManager.Instance.iceballCount > 0)
            {
                StartCoroutine(ShootIceballs(PlayerStatsManager.Instance.iceballCount, nearestEnemy));
            }
            if (PlayerStatsManager.Instance.APbulletCount > 0)
            {
                StartCoroutine(ShootAPbullet(PlayerStatsManager.Instance.APbulletCount, nearestEnemy));
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

            yield return new WaitForSeconds(0.05f);
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

            yield return new WaitForSeconds(0.07f);
        }
    }

    IEnumerator ShootAPbullet(int APbulletCount, GameObject nearestEnemy)
    {

        yield return new WaitForSeconds(PlayerStatsManager.Instance.bulletsPerShoot * 0.09f);

        for (int i = 0; i < APbulletCount; i++)
        {
            if (nearestEnemy == null)
                yield break;
            Debug.Log("instance AP");
            GameObject AP = Instantiate(APbulletPrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = nearestEnemy.transform.position - firePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            AP.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

            if (AP.GetComponent<APbullet>() != null)
            {
                AP.GetComponent<APbullet>().SetTarget(nearestEnemy.transform);
            }

            yield return new WaitForSeconds(0.15f);
        }
    }

    // Find the nearest enemy.
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
