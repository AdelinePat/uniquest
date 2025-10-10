using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int level;
    public bool isInArena;
    public float speed;
    public float arenaSpeed;
    public int facingDirection;
    public float posX;
    public float posY;

    public Bag bag;
    public Health health;
    public Attack attack;

    public PlayerData(Player player, float posX = 0f, float posY = 0f)
    {

        this.level = player.GetLevel();
        this.isInArena = player.GetIsInArena();
        this.speed = player.GetSpeed();
        this.arenaSpeed = player.GetArenaSpeed();
        this.facingDirection = player.facingDirection;
        this.posX = posX;
        this.posY = posY;

        this.health = player.GetHealth();
        this.attack = player.GetAttack();
        this.bag = player.bag;
    }

    public string ToJson() {
        return JsonUtility.ToJson(this, true);
    }

    
}