using System.Collections.Generic;
using UnityEngine;

public class WormObjectPool : MonoBehaviour
{
    public static WormObjectPool SharedInstance;
    public List<WormObj> pooledWorms;

    [SerializeField] WormObj wormToPool;
    [SerializeField] int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledWorms= new List<WormObj>();
        WormObj tempWorm;

        for (int i = 0; i < amountToPool; i++)
        {
            tempWorm = Instantiate(wormToPool);
            tempWorm.gameObject.SetActive(false);
            pooledWorms.Add(tempWorm);
        }
    }

    public WormObj GetPooledWorm()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledWorms[i].gameObject.activeInHierarchy)
            {
                return pooledWorms[i];
            }
        }

        return null;
    }
}
