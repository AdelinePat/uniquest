using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {
    private int currentHealth;
    private int maxHealth;
    private int defense;

    public Health(int maxHealth, int health, int defense) {
        this.maxHealth = maxHealth;
        this.currentHealth = health;
        this.defense = defense;
    }

    public void getDamage(int damage) {
        this.setCurrentHealth(this.currentHealth - damage);

        if (currentHealth <= 0) {
            gameObject.SetActive(false);
        }
    }

    public int getMaxHealth() {
        return this.maxHealth;
    }

    public int getCurrentHealth() {
        return this.currentHealth;
    }

    public int getDefense() {
        return this.defense;
    }


    public void setMaxHealth(int newValue) {
        this.maxHealth = newValue;
    }

    public void setCurrentHealth(int newValue) {
        this.currentHealth = newValue;      
    }

    public void setDefense(int newValue) {
        this.defense = newValue;
    }

}