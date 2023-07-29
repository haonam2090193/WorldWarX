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
        amountToPool = DataManager.Instance.GlobalConfig.maxBulletPoolSize;
        Bullet tmp;
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
}
