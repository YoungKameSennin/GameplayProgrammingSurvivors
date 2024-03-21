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

        foreach (GameObject bullet in bullets)
        {
            if (bullet != null)
            {
                bullet.transform.RotateAround(PlayerStatsManager.Instance.playerPosition.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            }
        }
    }

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
    public void BulletDestroyed(GameObject bullet)
    {
        bullets.Remove(bullet);
        if (respawnCoroutine == null)
        {
            // 如果当前没有协程在运行，则启动一个新的协程
            respawnCoroutine = StartCoroutine(RespawnBulletAfterDelay());
        }
        else
        {
            // 如果已经有一个协程在运行，那么重置计时器
            StopCoroutine(respawnCoroutine); // 停止当前协程
            respawnCoroutine = StartCoroutine(RespawnBulletAfterDelay()); // 重新启动协程以重置计时
        }
    }

    IEnumerator RespawnBulletAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        UpdateBullets(); // 更新子弹状态
        respawnCoroutine = null; // 重置协程变量，表示当前没有协程在运行
    }
}