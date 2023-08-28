using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public int maxEnemy;
    public float spawnTime;

    private int totalEnemy;
    private void Start()                                                                                                   
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (totalEnemy <= maxEnemy)
        {
            totalEnemy++;
            EnemiesSpawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }
    void EnemiesSpawn()
    {
        
        float randomYPos = Random.Range(0, 360);
        int randomEnemy = Random.Range(0, enemies.Length - 1);
        
        Instantiate(enemies[randomEnemy], this.transform.position, Quaternion.Euler(0,randomYPos,0));
    }
}