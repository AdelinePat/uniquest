using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Entity : MonoBehaviour {
    // public string name;
    private Health health;
    private float speed;
    private int strength;

    public abstract void attack(GameObject target);
    public abstract void move();

    public int getStrength() {
        return this.strength;
    }

    public float getSpeed() {
        return this.speed;
    }

    public Health getHealth() {
        return this.health;
    }

    public void setStrength(int newValue) {
        this.strength = newValue;
    }

    public void setSpeed(float newValue) {
        this.speed = newValue;
    }

    public void setHealth(Health newHealth) {
        this.health = newHealth;
    }
    // public void setMaxhealth(int newValue) {
    //     this.health.setMaxHealth(newValue);
    // }

    // public void setCurrentHealth(int newValue) {
    //     this.health.setCurrentHealth(newValue);
    // }

}
