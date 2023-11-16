using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHeal : MonoBehaviour
{
    public life Life;

    private void Awake()
    {
        Life = GameObject.FindObjectOfType<life>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Life.AddArmor();
        Destroy(this.gameObject);
    }
}
