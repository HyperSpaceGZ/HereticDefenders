using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5.0f; 
    private float PassTime = 0.0f;

    void Update()
    {
        PassTime += Time.deltaTime; 
        if (PassTime >= lifeTime)
        {
            lifeTime = PassTime;
            gameObject.SetActive(false);
            

        }
    }
}
