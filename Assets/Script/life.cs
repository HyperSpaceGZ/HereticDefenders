using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class life : MonoBehaviour, Iplayerenemydmg
{
    public Image lifeBar;
    public Image armorBar;

    public float MaxLife = 10f;
    public float currentLife;
    public float MaxArmor = 5f;
    public float currentArmor;

    public Material RedFlash;
    public Material BlueFlash;
    public Material DefMaterial;
    public SpriteRenderer sr;

    private void Start()
    {
       currentLife = PlayerPrefs.GetFloat("SavedLife", MaxLife);
       currentArmor = PlayerPrefs.GetFloat("SavedArmor", MaxArmor);

        sr = GetComponent<SpriteRenderer>();

        RedFlash = Resources.Load("RedFlash", typeof(Material)) as Material;
        BlueFlash = Resources.Load("BlueFlash", typeof(Material)) as Material;
        DefMaterial = sr.material;
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    public void PlayerDamage()
    { 
        currentArmor = Mathf.Max(0, currentArmor - 1f);
        sr.material = BlueFlash;
        if (currentArmor == 0 )
        {
            currentLife--;
            sr.material = RedFlash;
            if (currentLife <= 0)
            {
                EndGame();
            }
            else
            {
                Invoke("ResetMaterial", 0.1f);
            }
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }

    }
    void ResetMaterial()
    {
        sr.material = DefMaterial;
    }

    public void UpdateUI()
    {
        lifeBar.fillAmount = currentLife / MaxLife;
        armorBar.fillAmount = currentArmor / MaxArmor;
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

    public void OnDestroy()
    {
        PlayerPrefs.SetFloat("SavedLife", currentLife);
        PlayerPrefs.SetFloat("SavedArmor", currentArmor);
        PlayerPrefs.Save();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(4);
    }
}
