using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerryGoRound : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float rotationSpeed = 100f;
    public float distanceFromPlayer = 3f;
    public float respawnDelay = 3.8f;

    private Coroutine respawnCoroutine = null;
    private List<GameObject> bullets = new List<GameObject>();

    public void UpdateBullets()
    {
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        bullets.Clear();

        SpawnBullets();
    }

    void Update()
    {
        // Rotate all bullets around the player。
        foreach (GameObject bullet in bullets)
        {
            if (bullet != null)
            {
                bullet.transform.RotateAround(PlayerStatsManager.Instance.playerPosition.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            }
        }
    }

    // Spawn bullets around the player.
    void SpawnBullets()
    {
        float angleIncrement = 360f / PlayerStatsManager.Instance.MarryGoRoundCount;

        for (int i = 0; i < PlayerStatsManager.Instance.MarryGoRoundCount; i++)
        {
            float currentAngle = angleIncrement * i;
            float angleInRadians = currentAngle * Mathf.Deg2Rad;
            Vector3 bulletPosition = PlayerStatsManager.Instance.playerPosition.position +
                                     new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0) * distanceFromPlayer;

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity, this.transform);
            bullets.Add(bullet);
        }
    }

    void SpawnBullet()
    {
        Vector3 offset = new Vector3(distanceFromPlayer, 0, 0);
        GameObject bullet = Instantiate(bulletPrefab, PlayerStatsManager.Instance.playerPosition.position + offset, Quaternion.identity, this.transform);
        bullets.Add(bullet);
    }

    // Called when a bullet is destroyed.
    public void BulletDestroyed(GameObject bullet)
    {
        bullets.Remove(bullet);
        // If all bullets are destroyed, respawn them after a delay.
        if (respawnCoroutine == null)
        {
            respawnCoroutine = StartCoroutine(RespawnBulletAfterDelay());
        }
        else
        {
            // If a bullet is destroyed while the respawn coroutine is running, stop the coroutine and restart it.
            StopCoroutine(respawnCoroutine);
            respawnCoroutine = StartCoroutine(RespawnBulletAfterDelay());
        }
    }

    // Respawn all bullets after a delay.
    IEnumerator RespawnBulletAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        UpdateBullets();
        respawnCoroutine = null;
    }
}