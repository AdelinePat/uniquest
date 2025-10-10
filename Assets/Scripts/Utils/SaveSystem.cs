using System.IO;
using UnityEngine;
using System.Collections.Generic;

public static class SaveSystem
{
    // users/[username]/AppData/LocalLow/DefaultCompany/uniquest
    private static string path = Application.persistentDataPath + "/save.json";

    public static void SavePlayer(Player player)
    {
        PlayerData data = new PlayerData(player, 0f, 0f);
        string json = data.ToJson();
        File.WriteAllText(path, json);
        Debug.Log("Saved to: " + path);
    }

    public static PlayerData LoadPlayerData()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("No save file found.");
            return null;
        }

        string json = File.ReadAllText(path);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        return data;
    }


    public static void LoadPlayer(Player player, PlayerData data) {
        Bag bag = new Bag(
            data.bag.healthCount,
            data.bag.fleeCount,
            data.bag.defenseCount,
            data.bag.GetItemQuantityFixed()
        );
    
        Attack attack = new Attack(
            data.attack.GetStrength(),
            data.attack.GetDefense(),
            data.attack.GetDefense(),
            data.attack.GetSpecialAttackCount());

        Health health = new Health(
            data.health.GetMaxHealth(),
            data.health.GetCurrentHealth());

        player.SetHealth(health);
        player.SetAttack(attack);
        player.bag = bag;
        player.SetLevel(data.level);
        player.SetIsInArena(data.isInArena);
        player.SetSpeed(data.speed);
        player.SetArenaSpeed(data.arenaSpeed);
        player.facingDirection = data.facingDirection;
    }


}
