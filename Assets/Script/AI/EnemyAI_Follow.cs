using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Follow : EnemyAI
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            EnemyTrigger();
        }
    }
    protected virtual void EnemyFollowerMovement()
    {
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        EnemyNavMesh.SetDestination(PlayerTransform.position);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
