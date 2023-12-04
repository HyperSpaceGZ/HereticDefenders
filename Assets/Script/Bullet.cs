using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5.0f; 
    private float PassTime = 0.0f;
    public EnemyAI enemyAI;
    void Update()
    {
        PassTime += Time.deltaTime; 
        if (PassTime >= lifeTime)
        {
            DestroyBullet();
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ienemydamage>() != null)
        {
            collision.gameObject.GetComponent<Ienemydamage>().EnemyDamage();
        }
        DestroyBullet();
    }
    protected void DestroyBullet()
    {
        PassTime = 0.0f;
        gameObject.SetActive(false);
    }
}
