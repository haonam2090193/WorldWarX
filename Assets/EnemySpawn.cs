using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Tooltip("The list of enemy prefabs to spawn")]
    public List<GameObject> enemyPrefabs; 
    [Tooltip("The position where the enemies will spawn")]
    public Transform spawnPoint; 
    [Tooltip("The current number of spawned enemies")]
    public int enemyCount; 
    [Tooltip("The maximum number of enemies to spawn")]
    public int maxEnemy; 
    [Tooltip("The time interval between enemy spawns")]
    public float spawnTime;



    float rotationY; 

    IEnumerator SpawnEnemies()
    {
        while (enemyCount < maxEnemy)
        {
            rotationY = Random.Range(-180, 180);
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.Euler(0, rotationY, 0));
            enemy.transform.SetParent(spawnPoint.transform);
            yield return new WaitForSeconds(spawnTime);

            enemyCount++;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            enemyCount = 0;
            Debug.Log("Start Spawn");
            StartCoroutine(SpawnEnemies());
        }
    }
}