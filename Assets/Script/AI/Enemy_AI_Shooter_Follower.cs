using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Shooter_Follower : EnemyAI_Follow
{
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private Transform Spawner1;
    [SerializeField] private float EnemyBulletForce;
    [SerializeField] private float BulletFireRate;

    protected override void Awake()
    {
        base.Awake();
        Spawner1 = transform.GetChild(1);
        InvokeRepeating("ShootingEnemy", 1.5f, BulletFireRate);
    }

    protected virtual void ShootingEnemy()
    {
        GameObject bulletClone1 = Instantiate(EnemyBullet, Spawner1.position, Spawner1.rotation);
        Rigidbody2D rb1 = bulletClone1.GetComponent<Rigidbody2D>();
        rb1.AddRelativeForce(Vector3.up * EnemyBulletForce, ForceMode2D.Impulse);
    }

    protected override void EnemyDeath()
    {
        CancelInvoke("ShootingEnemy");
        base.EnemyDeath();
    }
}
