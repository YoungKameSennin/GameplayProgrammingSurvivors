using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private float spawnRadius = 5.0f;
    [SerializeField] public Tilemap tilemap;
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
        float xOffset = Mathf.Cos(randomAngle) * spawnRadius;
        float yOffset = Mathf.Sin(randomAngle) * spawnRadius;

        // Calculate spawn position around the player
        Vector3 spawnPosition = player.transform.position + new Vector3(xOffset, yOffset, 0);

        while (!IsPositionOnTilemap(spawnPosition))
        {   
            Debug.Log("Enemy spawned on tilemap, recalculating spawn position.");
            randomAngle = Random.Range(0f, Mathf.PI * 2f);
            xOffset = Mathf.Cos(randomAngle) * spawnRadius;
            yOffset = Mathf.Sin(randomAngle) * spawnRadius;
            spawnPosition = player.transform.position + new Vector3(xOffset, yOffset, 0);
        }

        // Instantiate a random enemy prefab at the calculated spawn position
        if (enemyPrefabs.Length > 0)
        {
            int prefabIndex = Random.Range(0, enemyPrefabs.Length);
            FindObjectOfType<SoundManager>().PlaySoundEffect("Spawn");
            Instantiate(enemyPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
        }
    }
}
