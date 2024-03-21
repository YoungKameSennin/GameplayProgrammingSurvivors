using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs1;
    [SerializeField] private GameObject[] enemyPrefabs2;
    [SerializeField] private GameObject[] enemyPrefabs3;
    [SerializeField] private GameObject[] enemyPrefabs4;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private float spawnRadius = 5.0f;
    [SerializeField] public Tilemap tilemap;
    private float spawnTimer = 0.0f;
    private PlayerStatsManager playerStatsManager;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerTransform = player.transform;
        playerStatsManager = player.GetComponent<PlayerStatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;
            SpawnEnemy();
        }
    }

    // Function to check if a position is on the Tilemap
    public bool IsPositionOnTilemap(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);

        TileBase tile = tilemap.GetTile(cellPosition);

        return tile != null;
    }

    void SpawnEnemy()
    {
        // Calculate a random angle in radians
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate random x and y offsets using trigonometry
        float xOffset1 = Mathf.Cos(randomAngle) * spawnRadius;
        float yOffset1 = Mathf.Sin(randomAngle) * spawnRadius;
        randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float xOffset2 = Mathf.Cos(randomAngle) * spawnRadius;
        float yOffset2 = Mathf.Sin(randomAngle) * spawnRadius;
        randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float xOffset3 = Mathf.Cos(randomAngle) * spawnRadius;
        float yOffset3 = Mathf.Sin(randomAngle) * spawnRadius;

        // Calculate spawn position around the player
        Vector3 spawnPosition1 = player.transform.position + new Vector3(xOffset1, yOffset1, 0);
        Vector3 spawnPosition2 = player.transform.position + new Vector3(xOffset2, yOffset2, 0);
        Vector3 spawnPosition3 = player.transform.position + new Vector3(xOffset3, yOffset3, 0);

        while (!IsPositionOnTilemap(spawnPosition1))
        {
            Debug.Log("Enemy spawned on tilemap, recalculating spawn position.");
            randomAngle = Random.Range(0f, Mathf.PI * 2f);
            xOffset1 = Mathf.Cos(randomAngle) * spawnRadius;
            yOffset1 = Mathf.Sin(randomAngle) * spawnRadius;
            spawnPosition1 = player.transform.position + new Vector3(xOffset1, yOffset1, 0);
        }

        while (!IsPositionOnTilemap(spawnPosition2))
        {
            Debug.Log("Enemy spawned on tilemap, recalculating spawn position.");
            randomAngle = Random.Range(0f, Mathf.PI * 2f);
            xOffset2 = Mathf.Cos(randomAngle) * spawnRadius;
            yOffset2 = Mathf.Sin(randomAngle) * spawnRadius;
            spawnPosition2 = player.transform.position + new Vector3(xOffset2, yOffset2, 0);
        }

        while (!IsPositionOnTilemap(spawnPosition3))
        {
            Debug.Log("Enemy spawned on tilemap, recalculating spawn position.");
            randomAngle = Random.Range(0f, Mathf.PI * 2f);
            xOffset3 = Mathf.Cos(randomAngle) * spawnRadius;
            yOffset3 = Mathf.Sin(randomAngle) * spawnRadius;
            spawnPosition3 = player.transform.position + new Vector3(xOffset3, yOffset3, 0);
        }


        // Instantiate a random enemy prefab at the calculated spawn position
        if (enemyPrefabs1.Length > 0 && enemyPrefabs2.Length > 0 && enemyPrefabs3.Length > 0 && enemyPrefabs4.Length > 0)
        {
            int prefabIndex1 = Random.Range(0, enemyPrefabs1.Length);
            int prefabIndex2 = Random.Range(0, enemyPrefabs2.Length);
            int prefabIndex3 = Random.Range(0, enemyPrefabs3.Length);
            FindObjectOfType<SoundManager>().PlaySoundEffect("Spawn");
            if (playerStatsManager.level < 3)
            {
                Instantiate(enemyPrefabs1[prefabIndex1], spawnPosition1, Quaternion.identity);
            }
            else if (playerStatsManager.level < 5)
            {
                Instantiate(enemyPrefabs1[prefabIndex1], spawnPosition1, Quaternion.identity);
                Instantiate(enemyPrefabs2[prefabIndex2], spawnPosition2, Quaternion.identity);
            }
            else if (playerStatsManager.level < 7)
            {
                Instantiate(enemyPrefabs1[prefabIndex1], spawnPosition1, Quaternion.identity);
                Instantiate(enemyPrefabs2[prefabIndex2], spawnPosition2, Quaternion.identity);
                Instantiate(enemyPrefabs3[prefabIndex3], spawnPosition3, Quaternion.identity);
            }

        }
    }
}
