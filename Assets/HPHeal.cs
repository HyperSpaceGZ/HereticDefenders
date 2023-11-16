using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHeal : MonoBehaviour
{
    public life Life;
    
    private void Awake()
    {
        Life = GameObject.FindObjectOfType<life>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Life.Heal();
        Destroy(this.gameObject);
    }
}
