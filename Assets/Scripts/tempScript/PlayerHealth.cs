using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    public void ChangeHealth(int amount) {
        currentHealth += amount;

        if (currentHealth <= 0) {
            gameObject.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
