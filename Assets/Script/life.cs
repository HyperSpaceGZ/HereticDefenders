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
        if (!PlayerPrefs.HasKey("GameStarted"))
        {
            PlayerPrefs.SetInt("GameStarted", 1);
            ResetValues();
        }
        else
        {
            currentLife = PlayerPrefs.GetFloat("SavedLife", MaxLife);
            currentArmor = PlayerPrefs.GetFloat("SavedArmor", MaxArmor);
        }
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    public void PlayerDamage()
    {
        currentArmor = Mathf.Max(0, currentArmor - 1f);
        if (currentArmor == 0)
        {
            currentLife--;
        }
    }

    public void UpdateUI()
    {
        lifeBar.fillAmount = currentLife / MaxLife;
        armorBar.fillAmount = currentArmor / MaxArmor;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("SavedLife", currentLife);
        PlayerPrefs.SetFloat("SavedArmor", currentArmor);
        PlayerPrefs.Save();
    }

    private void ResetValues()
    {
        currentLife = MaxLife;
        currentArmor = MaxArmor;
    }

    public void Heal()
    {
        if(currentLife < MaxLife)
        {
            currentLife = MaxLife;
        }
    }

    public void AddArmor() 
    {
        if (currentArmor < MaxArmor)
        {
            currentArmor = MaxArmor;
        }
    }
      



}
