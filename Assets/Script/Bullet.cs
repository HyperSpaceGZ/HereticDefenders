using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5.0f; 
    private float PassTime = 0.0f;

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
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        PassTime = 0.0f;
        gameObject.SetActive(false);
    }
}
