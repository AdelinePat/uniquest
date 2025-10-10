using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System;

[Serializable]
public class Bag
{
    public static int itemQuantity = 3;
    [SerializeField] private int itemQuantityFixed = 3;
    public HealthPotion[] healthPotions = new HealthPotion[itemQuantity];
    public FleePotion[] fleePotions = new FleePotion[itemQuantity];
    public DefensePotion[] defensePotions = new DefensePotion[itemQuantity];

    [SerializeField] public int healthCount;
    [SerializeField] public int fleeCount;
    [SerializeField] public int defenseCount;

    public Bag()
    {
        itemQuantity = this.itemQuantityFixed;
        this.healthCount = itemQuantity;
        this.fleeCount = itemQuantity;
        this.defenseCount = itemQuantity;

        for (int i = 0; i < itemQuantity; i++)
        {
            healthPotions[i] = new HealthPotion();
            fleePotions[i] = new FleePotion();
            defensePotions[i] = new DefensePotion();
        }
    }

    public Bag(int healthCount, int fleeCount, int defenseCount, int itemQuantityFixed) {
        this.healthCount = healthCount;
        this.fleeCount = fleeCount;
        this.defenseCount = defenseCount;
        this.itemQuantityFixed = itemQuantityFixed;
        Bag.itemQuantity = this.itemQuantityFixed;

        for (int i = 0; i < this.healthCount; i++) this.healthPotions[i] = new HealthPotion();
        for (int i = 0; i < this.fleeCount; i++) this.fleePotions[i] = new FleePotion();
        for (int i = 0; i < this.defenseCount; i++) this.defensePotions[i] = new DefensePotion();
    }

    private void Use(Item[] itemsList, Entity target)
    {
        for (int i = 0; i < itemQuantity; i++)
        {
            if (itemsList[i] != null)
            {
                Item testPotion = itemsList[i];
                itemsList[i].Effect(target);
                itemsList[i] = null;
                return;
            }
        }
    }


    public void Use(Entity target, System.Type potionType)
    {
        if (potionType == typeof(HealthPotion))
        {
            Use(healthPotions, target);
            healthCount--;
        }

        if (potionType == typeof(FleePotion))
        {
            Use(fleePotions, target);
            fleeCount--;
        }

        if (potionType == typeof(DefensePotion))
        {
            Use(defensePotions, target);
            defenseCount--;
        }
    }


    public void Refill()
    {
        int max = itemQuantity;

        for (int i = 0; i < max; i++)
        {

            if (healthPotions[i] == null)
            {
                healthPotions[i] = new HealthPotion();
            }
        }
        healthCount = max;


        for (int i = 0; i < max; i++)
        {
            if (fleePotions[i] == null)
            {
                fleePotions[i] = new FleePotion();
            }
        }
        fleeCount = max;


        for (int i = 0; i < max; i++)
        {
            if (defensePotions[i] == null)
            {
                defensePotions[i] = new DefensePotion();
            }
        }
        defenseCount = max;

        Debug.Log(" Le sac est maintenant plein (3 potions de chaque) !");
    }

    public string ToParagraphString() {
        return $"Potion de soin : {this.healthCount}\n" +
        $"Potion de fuite : {this.fleeCount}\n" +
        $"Potion de défense : {this.defenseCount}\n";
    }

    public int GetItemQuantityFixed() {
        return this.itemQuantityFixed;
    }

    public void SetItemQuantityFixed(int newValue) {
        this.itemQuantityFixed = newValue;
    }
}
