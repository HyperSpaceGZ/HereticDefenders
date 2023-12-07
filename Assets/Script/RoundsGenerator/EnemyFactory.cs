using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [Header("poner 1n° menos por la lenght")]
    public int TotalEnemysToCreate = 20; 

    private int EnemysCount = 0;

    public GameObject CreateEnemy(Vector3 position)
    {
        if (EnemysCount < TotalEnemysToCreate)
        {
            if (enemyPrefabs.Length == 0)
            {
                Debug.LogError("Faltan prefabs :p");
                return null;
            }

            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomEnemyIndex], position, Quaternion.identity);

            EnemysCount++;
            if (EnemysCount >= TotalEnemysToCreate)
            {
                
                enabled = false;
            }

            return enemy;
        }

        return null; 
    }
}