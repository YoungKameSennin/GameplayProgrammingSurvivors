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
            Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(spawnRadiusMin, spawnRadiusMax);
            Vector2 spawnPosition = new Vector2(player.transform.position.x + randomCircle.x, player.transform.position.y + randomCircle.y);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
