using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDebuff : Bullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ienemyslowness>() != null)
        {
            collision.gameObject.GetComponent<Ienemyslowness>().Slowness();
        }
        DestroyBullet();
    }
}
