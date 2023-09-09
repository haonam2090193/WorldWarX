using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<Transform> spawnPoints; // Danh sách các spawn point
    public int enemyCount;
    public int maxEnemy;
    public float spawnTime;

    float rotationY;

    private void SpawnEnemies()
    {
        while (enemyCount < maxEnemy)
        {
            rotationY = Random.Range(-180, 180);
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Count); // Chọn một spawn point ngẫu nhiên
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count); // Chọn một enemy prefab ngẫu nhiên
            Transform randomSpawnPoint = spawnPoints[randomSpawnPointIndex];
            GameObject enemyPrefab = enemyPrefabs[randomEnemyIndex];
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.Euler(0, rotationY, 0));
            enemyCount++;
            if (enemyCount == maxEnemy)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Aaa");
        SpawnEnemies();
    }
}