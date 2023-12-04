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

    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D collider2D;

    public delegate void KillEvent();
    public static KillEvent killevent;

    protected virtual void Awake()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        animator = transform.GetChild(0).GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
            EnemyDeath();
        }
    }
    protected virtual void EnemyDeath()
    {
        CancelInvoke("EnemyFollowerMovement");
        EnemyNavMesh.ResetPath();
        collider2D.enabled = false;
        killevent?.Invoke();
        animator.SetBool("IsDead", true);
        Destroy(this.gameObject, 0.35f);
    }
}