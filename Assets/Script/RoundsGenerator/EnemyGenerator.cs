using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerator : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public Transform[] spawnPoints;

    public int TotalEnemys = 20;
    public float TimeMinCreation = 2f;
    public float TimeMaxCreation = 5f;

    private float TimeToNextCreation;
    private float[] TimesForSpawners;
    private int EnemysCount = 0;


    private void Start()
    {
        TimesForSpawners = new float[spawnPoints.Length];
        TimeToNextCreation = Time.time + Random.Range(TimeMinCreation, TimeMaxCreation);

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            TimesForSpawners[i] = Time.time + Random.Range(TimeMinCreation, TimeMaxCreation);
        }
    }

    private void Update()
    {
        if(Time.time >= TimeToNextCreation)
        {
            CreateEnemys();
            TimeToNextCreation = Time.time + Random.Range(TimeMinCreation, TimeMaxCreation);

        }
    }

    void CreateEnemys()
    {
        int randomSpawner = Random.Range(0, spawnPoints.Length);
        if (Time.time >= TimesForSpawners[randomSpawner])
        {
            GameObject enemy = enemyFactory.CreateEnemy(spawnPoints[randomSpawner].position);

            TimesForSpawners[randomSpawner] = Time.time + Random.Range(TimeMinCreation, TimeMaxCreation);
            EnemysCount++;
            if (EnemysCount >= TotalEnemys)
            {
                enabled = false;
            }
        }
    }
}
