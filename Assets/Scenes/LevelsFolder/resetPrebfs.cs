using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPrebfs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("SavedLife");
        PlayerPrefs.DeleteKey("SavedArmor");
    }
}
