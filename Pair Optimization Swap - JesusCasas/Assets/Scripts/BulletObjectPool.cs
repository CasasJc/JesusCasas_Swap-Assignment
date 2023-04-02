using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool SharedInstance;
    public List<GameObject> pooledBullets;

    [SerializeField] GameObject bulletToPool;
    [SerializeField] int amountToPool;


    [SerializeField] private Transform shootPoint;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledBullets = new List<GameObject>();
        GameObject tempBullet;

        for (int i = 0; i < amountToPool; i++)
        {
            tempBullet = Instantiate(bulletToPool, shootPoint.position, shootPoint.rotation);
            tempBullet.SetActive(false);
            pooledBullets.Add(tempBullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        return null;
    }
}
