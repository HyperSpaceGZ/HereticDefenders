using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuff : MonoBehaviour, Ienemyslowness
{
    public PlayerMovement PlayerMovement;
    private void Awake()
    {
        PlayerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    public void Slowness()
    {
        PlayerMovement.speed = 5;
        Invoke("ResetSlowness", 3.5f);
        Debug.Log("slowness");
    }

    public void ResetSlowness()
    {
        PlayerMovement.speed = 10;
        Debug.Log("reset slowness");
    }
}
