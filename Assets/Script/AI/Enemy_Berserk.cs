using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Berserk : EnemyAI_Follow
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.GetComponent<Ienemyslowness>() != null)
        {
            collision.gameObject.GetComponent<Ienemyslowness>().SlownessBerserk();
        }
    }
}