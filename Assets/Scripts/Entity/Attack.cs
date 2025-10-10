using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

[Serializable]
public class Attack {
    [SerializeField] private int strength;
    [SerializeField] private int defense;
    private int temporaryDefense;

    
    public const int SPECIAL_ATTACK_COUNT = 5;
    // private int specialAttackFixed;
    private System.Random random;

    [SerializeField] private int specialAttackCount;

    public Attack(int strength,
                int defense,
                int temporaryDefense) {
        this.strength = strength;
        this.defense = defense;
        this.temporaryDefense = temporaryDefense;
        this.specialAttackCount = Attack.SPECIAL_ATTACK_COUNT;
    }

    public Attack(int strength,
                int defense,
                int temporaryDefense,
                int specialAttackCount) {
                    
        this.strength = strength;
        this.defense = defense;
        this.temporaryDefense = temporaryDefense;
        this.specialAttackCount = specialAttackCount;
    }

    
    public void NormalAttack(Entity attacker, Entity target) {
        string type;
        if(target.GetType() == typeof(Player)) {
            type = "player";
        } else {
            type = "enemy";
        }

        int before = target.GetHealth().GetCurrentHealth();

        AttackUtils.Damage(attacker, target, this.random);

        int after = target.GetHealth().GetCurrentHealth();
        int finalDamage = before - after;
    }

    public void SpecialAttack(Entity attacker, Entity target) {
        if (specialAttackCount == 0) return;
        string type;
        if(target.GetType() == typeof(Player)) {
            type = "player";
        } else {
            type = "enemy";
        }

        int before = target.GetHealth().GetCurrentHealth();

        AttackUtils.SpecialDamage(attacker, target, this.random);

        int after = target.GetHealth().GetCurrentHealth();
        int finalDamage = before - after;

        this.specialAttackCount--;
    
    }


    public int GetStrength() {
        return this.strength;
    }

    public int GetDefense() {
        return this.defense;
    }

    public int GetTemporaryDefense() {
        return this.temporaryDefense;
    }

    public int GetSpecialAttackCount() {
        return this.specialAttackCount;
    }

    public int GetSpecialAttackFixed() {
        // return this.specialAttackFixed;
        return Attack.SPECIAL_ATTACK_COUNT;
    }


    public void SetStrength(int newValue) {
        this.strength = newValue;
    }

    public void SetDefense(int newValue) {
        this.defense = newValue;
    }

    public void SetTemporaryDefense(int newValue) {
        this.temporaryDefense = newValue;
    }

    public void SetSpecialAttackCount(int newValue) {
        this.specialAttackCount = newValue;
    }

  
}
