using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5.0f; 
    private float PassTime = 0.0f;
    public EnemyAI enemyAI;
    public void Awake()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
    }
    void Update()
    {
        PassTime += Time.deltaTime; 
        if (PassTime >= lifeTime)
        {
            DestroyBullet();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ienemydamage>() != null)
        {
            collision.gameObject.GetComponent<Ienemydamage>().EnemyDamage();
            enemyAI.EnemyTrigger();
        }
        DestroyBullet();
    }
    private void DestroyBullet()
    {
        PassTime = 0.0f;
        gameObject.SetActive(false);
    }
}
