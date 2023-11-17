using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private int Kills;
    [SerializeField] private int MaxKills;
    public EnemyGenerator enemyGenerator;

    private void Awake()
    {
        enemyGenerator = GameObject.FindObjectOfType<EnemyGenerator>();
        MaxKills = enemyGenerator.TotalEnemys;
    }

    private void AddKill()
    {
        Kills++;
        if(Kills == MaxKills)
        {
            Debug.Log("You Win!");
        }
    }

    private void OnEnable()
    {
        EnemyAI.killevent += AddKill;
    }
    private void OnDisable()
    {
        EnemyAI.killevent -= AddKill;
    }
}
