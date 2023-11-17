using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeShoot : ClassPowerUp
{
    public GameObject mainCannon;
    public GameObject CannonRight;
    public GameObject CannonLeft;
    public GameObject CannonMid;
    
    public override void Activate()
    {      
        mainCannon.SetActive(false);
        CannonRight.SetActive(true);
        CannonLeft.SetActive(true);
        CannonMid.SetActive(true);
    }
    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
