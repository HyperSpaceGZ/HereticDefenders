using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, Ienemydamage
{
    [SerializeField] protected Transform PlayerTransform;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected NavMeshAgent EnemyNavMesh;
    [SerializeField] protected bool hastriggered;
    [SerializeField] protected int health;

    public delegate void KillEvent();
    public static KillEvent killevent;

    protected virtual void Awake()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("EnemyFollowerMovement", 0, 0.02f);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Iplayerenemydmg>() != null)
        {
            collision.gameObject.GetComponent<Iplayerenemydmg>().PlayerDamage();
        }
    }
    public void EnemyDamage()
    {
        health--;
        if (health <= 0)
        {
            CancelInvoke("EnemyFollowerMovement");
            killevent?.Invoke();
            Destroy(this.gameObject);
        }
    }
}