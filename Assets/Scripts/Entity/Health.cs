using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using System;

[Serializable]
public class Health {
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    public Health(int maxHealth,
                int health) {
        this.maxHealth = maxHealth;
        this.currentHealth = health;
    }

    public void GetDamage(int damage) {

        if (this.currentHealth - damage < 0) {
           this.SetCurrentHealth(0);
        } else {
           this.SetCurrentHealth(this.currentHealth - damage);
        }
    }

    public int GetMaxHealth() {
        return this.maxHealth;
    }

    public int GetCurrentHealth() {
        return this.currentHealth;
    }

    public void SetMaxHealth(int newValue) {
        this.maxHealth = newValue;
    }

    public void SetCurrentHealth(int newValue) {
        this.currentHealth = newValue;      
    }

    private void Start() {
    }

    public string ToJson() {
        return JsonUtility.ToJson(this, true);
    }

   
}