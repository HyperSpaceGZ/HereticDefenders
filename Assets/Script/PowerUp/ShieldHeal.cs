using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHeal : ClassPowerUp
{
    public life Life;

    private void Awake()
    {
        Life = GameObject.FindObjectOfType<life>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Life.AddArmor();
        Deactivate();
    }

    public override void Activate()
    {
        Debug.Log("shield");
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
