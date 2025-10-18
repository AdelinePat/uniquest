using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class AttackUtilsTest
{
    public Player player;
    public Enemy enemy;
    // SpecialDamage
    

    [SetUp]
    public void Setup()
    {
        GameObject playerGO = new GameObject("Player");
        player = playerGO.AddComponent<Player>();
        player.SetHealth(new Health(50, 50));
        player.SetAttack(new Attack(10, 0, 0));
        // player.SetStrength(10);
        player.SetSpeed(5f);

        GameObject enemyGO = new GameObject("Enemy");
        enemy = enemyGO.AddComponent<Enemy>();
        enemy.SetHealth(new Health(30, 30));
        player.SetAttack(new Attack(10, 5, 5));
        // enemy.SetStrength(5);
        enemy.SetSpeed(2f);
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(player.gameObject);
        GameObject.DestroyImmediate(enemy.gameObject);
    }

    [Test]
    public void DamageReducesHealthProperly()
    {
        int enemyHealthBefore = enemy.GetHealth().GetCurrentHealth();

        AttackUtils.Damage(player, enemy);

        int enemyHealthAfter = enemy.GetHealth().GetCurrentHealth();
        int damageDone = enemyHealthBefore - enemyHealthAfter;

        Debug.Log($"Damage dealt by Player to Enemy: {damageDone}");

        Assert.Greater(damageDone, 0, "Damage should reduce health");
        Assert.AreEqual(damageDone, player.GetAttack().GetStrength() - enemy.GetAttack().GetTemporaryDefense(), "Damage equal player.strength - enemy.tempDefense");
        Assert.LessOrEqual(enemyHealthAfter, enemyHealthBefore, "Enemy health should decrease");
    }
    
    [Test]
    public void SpecialDamageReducesHealthProperly()
    {  
        int enemyHealthBefore = enemy.GetHealth().GetCurrentHealth();

        AttackUtils.SpecialDamage(player, enemy);

        int enemyHealthAfter = enemy.GetHealth().GetCurrentHealth();
        int damageDone = enemyHealthBefore - enemyHealthAfter;

        Debug.Log($"Damage dealt by Player to Enemy: {damageDone}");

        Assert.Greater(damageDone, 0, "Damage should reduce health");
        Assert.AreEqual(damageDone, player.GetAttack().GetStrength(), "EDamage equal player.strength");
        Assert.LessOrEqual(enemyHealthAfter, enemyHealthBefore, "Enemy health should decrease");
    }

}
