using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject CreateEnemy(Vector3 position)
    {
        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("faltan prefabs :p");
            return null;
        }
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[randomEnemyIndex], position, Quaternion.identity);

        return enemy;
    }
}