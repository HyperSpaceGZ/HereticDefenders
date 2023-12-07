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
    [SerializeField] private BoxCollider2D enemycollider2D;
    [SerializeField] private Material WhiteFlash;
    [SerializeField] private Material DefMaterial;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] AudioSource deathsound;

    public delegate void KillEvent();
    public static KillEvent killevent;

    protected virtual void Awake()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        animator = transform.GetChild(0).GetComponent<Animator>();
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        deathsound = GetComponent<AudioSource>();
        enemycollider2D = GetComponent<BoxCollider2D>();

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        WhiteFlash = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        DefMaterial = sr.material;
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
        sr.material = WhiteFlash;
        if (health <= 0)
        {
            EnemyDeath();
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }
    }

    void ResetMaterial()
    {
        sr.material = DefMaterial;
    }

    protected virtual void EnemyDeath()
    {
        ResetMaterial();
        CancelInvoke("EnemyFollowerMovement");
        EnemyNavMesh.ResetPath();
        enemycollider2D.enabled = false;
        killevent?.Invoke();
        animator.SetBool("IsDead", true);
        deathsound.Play();
        Destroy(this.gameObject, 0.35f);
    }
}