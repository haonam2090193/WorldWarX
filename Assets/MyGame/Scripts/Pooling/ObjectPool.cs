using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : BaseManager<ObjectPool>
{
    public List<Bullet> pooledObjects;
    public List<Enemy> pooledEnemyObjects;
    public Bullet objectToPool;
    public Enemy objectToPoolE;
    private int amountToPool;
    private int amountToPoolE;
    private void Start()
    {
        pooledObjects = new List<Bullet>();
        pooledEnemyObjects = new List<Enemy>();
        amountToPool = DataManager.Instance.GlobalConfig.maxBulletPoolSize;
        amountToPoolE = DataManager.Instance.GlobalConfig.maxEnemyPoolSize;
        Bullet tmp;
        Enemy enemy;
        for (int i = 0; i < amountToPoolE; i++)
        {
            enemy = Instantiate(objectToPoolE, this.transform,true);
            enemy.Deactive();
            pooledEnemyObjects.Add(enemy);
        }
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool,this.transform,true);
            tmp.Deactive();
            pooledObjects.Add(tmp);
        }
    }

    public Bullet GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].IsActive)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    public Enemy GetPooledObjectE()
    {
        for (int i = 0; i < amountToPoolE; i++)
        {
            if (!pooledEnemyObjects[i].IsActive)
            {
                return pooledEnemyObjects[i];
            }
        }
        return null;
    }
}
