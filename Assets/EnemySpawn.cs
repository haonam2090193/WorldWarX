using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Danh sách Prefab enemy
    public Transform spawnPoint; // Vị trí triệu hồi
    public int numberOfEnemies = 5; // Số lượng enemy cần triệu hồi
    public float summonRadius = 5f; // Bán kính triệu hồi

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            SpawnEnemies();
        }
    }
    void SpawnEnemies()
    {
        for (int i = 0; i <= numberOfEnemies; i++)
        {
            if (i <= numberOfEnemies)
            {
                GameObject enemyPrefab = enemyPrefabs[i];

                Vector3 randomOffset = Random.insideUnitSphere * summonRadius;
                Vector3 spawnPosition = spawnPoint.position + randomOffset;

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnPoint.position, summonRadius);
    }
}