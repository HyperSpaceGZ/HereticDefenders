using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemys;
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
        int RandomSpawner = Random.Range(0, spawnPoints.Length);
        if (Time.time >= TimesForSpawners[RandomSpawner])
        {
            int RandomEnemy = Random.Range(0, enemys.Length);
            Instantiate(enemys[RandomEnemy], spawnPoints[RandomSpawner].position, Quaternion.identity);
            TimesForSpawners[RandomSpawner] = Time.time + Random.Range(TimeMinCreation, TimeMaxCreation);
            EnemysCount++;
            if (EnemysCount >= TotalEnemys)
            {
                enabled = false;
            }
        }
        
        
    }

}
