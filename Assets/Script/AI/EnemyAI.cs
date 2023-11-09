using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] protected Transform PlayerTransform;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected NavMeshAgent EnemyNavMesh;
    [SerializeField] protected bool hastriggered;

    [SerializeField] protected int health;

    protected virtual void Awake()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            EnemyDeathCheck();
        }
        
        if (hastriggered == false && collision.gameObject.tag == "bullet")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
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
    protected virtual void EnemyDeathCheck()
    {
        if (health < 0)
        {
            KillEnemy();
        }
    }

    protected virtual void KillEnemy()
    {
        CancelInvoke("EnemyFollowerMovement");
        Destroy(this.gameObject);
    }
}
