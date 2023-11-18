using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHeal : ClassPowerUp
{
    public life Life;
    
    private void Awake()
    {
        Life = GameObject.FindObjectOfType<life>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Life.Heal();
        Deactivate();
    }

    public override void Activate()
    {
        Debug.Log("hp");
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
