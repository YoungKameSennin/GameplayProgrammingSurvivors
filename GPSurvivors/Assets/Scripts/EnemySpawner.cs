using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private float spawnRadius = 5.0f;
    private float spawnTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;
            Vector3 spawnPosition = player.transform.position + Random.insideUnitSphere * spawnRadius + new Vector3(0, 0, 0);
            spawnPosition.z = 0;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
