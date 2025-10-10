using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Entity : MonoBehaviour {
    protected const int DEFAULT_HP = 10;
    public Health health = new Health(Entity.DEFAULT_HP, Entity.DEFAULT_HP);

    public Attack attack = new Attack(3, 1, 1);

    protected const float DEFAULT_SPEED = 5f;
    protected const int DEFAULT_LEVEL = 1;
    protected const int BASE_STRENGHT = 3;

    public bool isInArena = false;

    private int level = DEFAULT_LEVEL;

    private float speed = DEFAULT_SPEED;

    private float arenaSpeed;

    public System.Random random;


    public abstract void Move();

    
    
    public bool GetIsInArena() {
        return this.isInArena;
    }

    public int GetLevel() {
        return this.level;
    }

    public float GetSpeed() {
        return this.speed;
    }

    public float GetArenaSpeed() {
        return this.arenaSpeed;
    }

    public Health GetHealth() {
        return this.health;
    }

    public Attack GetAttack() {
        return this.attack;
    }
    

    public void SetIsInArena(bool boolean) {
        this.isInArena = boolean;
    }

    public void SetLevel(int newLevel) {
        this.level = newLevel;
    }

    public void SetSpeed(float newValue) {
        this.speed = newValue;
    }

    public void SetArenaSpeed(float newValue) {
        this.arenaSpeed = newValue;
    }

    public void SetHealth(Health newHealth) {
        this.health = newHealth;
    }

    public void SetAttack(Attack newAttack) {
        this.attack = newAttack;
    }

    public void ToDebugString(string who) {
        Debug.Log($"{who.ToUpper()} ==> \n HP max: {this.GetHealth().GetMaxHealth()} -- HP: {this.GetHealth().GetCurrentHealth()} -- Force: {this.GetAttack().GetStrength()}");
    }

    public string ToParagraphString() {
        return $"Niveau: {this.GetLevel()}\n" +
        $"PV max: {this.GetHealth().GetMaxHealth()}\n" +
        $"PV : {this.GetHealth().GetCurrentHealth()}\n" +
        $"Force: {this.GetAttack().GetStrength()}\n" +
        $"Vitesse: {this.GetArenaSpeed()}\n" +
        $"Défense: {this.GetAttack().GetTemporaryDefense()}";
    }

    public void UpdateStat(int pastLevel) {
        System.Random random = new System.Random();
        int addStrength = random.Next(2,8);
        int addDefense = random.Next(2,8);

        int addHealth = random.Next(4,10);

        int addSpeed = random.Next(4,6);

        int gap = this.level - pastLevel;

        for(int i = 0; i < gap; i++) {
            int currentSpeedATen = (int) this.GetArenaSpeed() / 10;

            this.GetHealth().SetMaxHealth(this.GetHealth().GetMaxHealth() + addHealth);
            this.GetHealth().SetCurrentHealth(this.GetHealth().GetMaxHealth());


            this.GetAttack().SetDefense(this.GetAttack().GetDefense() + addDefense);

            this.GetAttack().SetTemporaryDefense(this.GetAttack().GetDefense());
            this.SetArenaSpeed( this.GetArenaSpeed() + addSpeed);

            int newATen = (int) this.GetArenaSpeed() / 10;
            if (currentSpeedATen < newATen) {
                addStrength += 2;
            }

            this.GetAttack().SetStrength(this.GetAttack().GetStrength() + addStrength);
        }
    }

    public virtual void ApplyDefaultStats() {
        this.SetSpeed(5f);
        this.SetLevel(1);
        this.SetHealth(new Health(Entity.DEFAULT_HP, Entity.DEFAULT_HP));
        this.SetAttack(new Attack(Entity.BASE_STRENGHT, 1, 1));
        // this.GetAttack().SetDefense(1);
        this.GetAttack().SetTemporaryDefense(this.GetAttack().GetDefense());
        this.GetHealth().SetMaxHealth(this.GetHealth().GetMaxHealth() + 5);
        this.GetHealth().SetCurrentHealth(this.GetHealth().GetMaxHealth());
        this.SetArenaSpeed(this.GetSpeed() + 5);
    }

    
}
