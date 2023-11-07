using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }

    public static ObjectPooling SharedInstance;
    public List<List<GameObject>> pooledObjectsLists; // lista tipos de bala
    public List<GameObject> bulletPrefabs; // Lista de prefabs
    public int amountToPool;
    public List<int> amountsToPool; // numero de los elementos

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjectsLists = new List<List<GameObject>>();
        InitializePools();
    }

    void InitializePools()
    {
        if (bulletPrefabs.Count != amountsToPool.Count)
        {
            Debug.LogError("el n° amount debe ser igual a la cantidad de elemntos");
            return;
        }
        foreach (GameObject prefab in bulletPrefabs)
        {
            List<GameObject> bulletType = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                bulletType.Add(obj);
            }
            pooledObjectsLists.Add(bulletType);
        }
    }

    public GameObject GetPooledObject(int bulletType)
    {
        List<GameObject> selectedList = pooledObjectsLists[bulletType - 1];

        for (int i = 0; i < selectedList.Count; i++)
        {
            if (!selectedList[i].activeInHierarchy)
            {
                return selectedList[i];
            }
        }

        // si me quedo sin
        GameObject newBullet = Instantiate(bulletPrefabs[bulletType - 1]);
        newBullet.SetActive(false);
        selectedList.Add(newBullet);
        return newBullet;
    }
}
