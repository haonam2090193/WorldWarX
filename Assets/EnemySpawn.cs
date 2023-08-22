using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemies;

    public Transform spawnPoint;
    public int enemyCount;
    float rotationY;
    public int maxEnemy;
    public float spawnTime;
    IEnumerator EnemyDrop()
    {
        enemies.SetActive(true);

        while (enemyCount < maxEnemy)
        {
            rotationY = Random.Range(-180, 180);
            // enemies.transform.rotation = Quaternion.Euler(0, rotationY, 0);

            // xPos = Random.Range(1, 50);
            // zPos = Random.Range(1, 30);
            Instantiate(enemies, spawnPoint.position, Quaternion.Euler(0, rotationY, 0));
            yield return new WaitForSeconds(spawnTime);
            enemyCount += 1;

        }
    }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.P))
            {
                enemyCount = 0;
                Debug.Log("Start Spawn");
                StartCoroutine(EnemyDrop());

            }
        }   
}
