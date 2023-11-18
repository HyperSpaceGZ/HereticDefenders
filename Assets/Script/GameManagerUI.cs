using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private int Kills;
    [SerializeField] private int MaxKills;
    [SerializeField] private TMP_Text EnemyCountTMP;
    [SerializeField] private GameObject WinPanel;
    public EnemyGenerator enemyGenerator;

    private void Awake()
    {
        enemyGenerator = GameObject.FindObjectOfType<EnemyGenerator>();
        MaxKills = enemyGenerator.TotalEnemys;
    }

    private void FixedUpdate()
    {
        EnemyCountTMP.text = "Enemies: "+Kills+"/"+MaxKills;
    }

    private void AddKill()
    {
        Kills++;
        if(Kills == MaxKills)
        {
            Invoke("Win", 2);
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

    private void Win()
    {
        Debug.Log("You Win!");
        WinPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
