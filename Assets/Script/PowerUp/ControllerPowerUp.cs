using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPowerUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            
            ClassPowerUp powerUp = other.GetComponent<ClassPowerUp>();

            if (powerUp != null )
            {
                powerUp.Activate();
                DeactivateAllPowerUps();
            }
        }
    }
    void DeactivateAllPowerUps()
    {
        ClassPowerUp[] powerUps = FindObjectsOfType<ClassPowerUp>();
        foreach (ClassPowerUp powerUp in powerUps)
        {
            powerUp.Deactivate();
            Destroy(powerUp.gameObject);
        }
    }
}
