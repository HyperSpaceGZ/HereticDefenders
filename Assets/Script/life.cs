using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour, Iplayerenemydmg
{
    public Image lifeBar;
    public Image armorBar;

    public float MaxLife = 10f;
    public float currentLife;
    public float MaxArmor = 5f;
    public float currentArmor;

    private void Start()
    {
        currentLife = MaxLife;
        currentArmor = MaxArmor;  
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    public void PlayerDamage()
    { 
        currentArmor = Mathf.Max(0, currentArmor - 1f);
        if(currentArmor == 0 )
        {
            currentLife--;   
        }
    }

    public void UpdateUI()
    {
        lifeBar.fillAmount = currentLife / MaxLife;
        armorBar.fillAmount = currentArmor / MaxArmor;
    }

}
