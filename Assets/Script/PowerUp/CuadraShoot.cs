using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadraShoot : ClassPowerUp
{
    public GameObject mainCannon;
    public GameObject CannonRight;
    public GameObject CannonLeft;
    public GameObject CannonUp;
    public GameObject CannonDown;
    public override void Activate()
    {
        mainCannon.SetActive(false);
        CannonRight.SetActive(true);
        CannonLeft.SetActive(true);
        CannonUp.SetActive(true);
        CannonDown.SetActive(true);
    }
}
