using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSave : MonoBehaviour
{
    public Image lifeBar;
    public Image armorBar;

    void Start()
    {
        
        float savedLife = PlayerPrefs.GetFloat("SavedLife", 10f); 
        float savedArmor = PlayerPrefs.GetFloat("SavedArmor", 5f); 

        
        lifeBar.fillAmount = savedLife / 10f; 
        armorBar.fillAmount = savedArmor / 5f; 
    }
}
