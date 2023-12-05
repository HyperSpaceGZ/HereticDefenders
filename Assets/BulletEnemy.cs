using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Iplayerenemydmg>() != null)
        {
            collision.gameObject.GetComponent<Iplayerenemydmg>().PlayerDamage();
        }
        DestroyBullet();
    }
}
