using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class AttackUtilsTest
{
    public Player player;
    public Enemy enemy;
    

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
        player.SetAttack(new Attack(10, 0, 0));
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
        Assert.LessOrEqual(enemyHealthAfter, enemyHealthBefore, "Enemy health should decrease");
    }

    [Test]
    public void DamageDeterministicHits() 
    {
        player.GetAttack().SetStrength(10);
        enemy.SetHealth(new Health(30, 30));
        enemy.SetAttack(new Attack(10, 0, 0));

        System.Random random = new System.Random(12345);

        bool weakOccurred = false;
        bool critOccurred = false;

        for (int i = 0; i < 100; i++)
        {
            enemy.GetHealth().SetCurrentHealth(30);
            AttackUtils.Damage(player, enemy, random);

            int remaining = enemy.GetHealth().GetCurrentHealth();
            int damageDone = 30 - remaining;

            if (damageDone > player.GetAttack().GetStrength()) critOccurred = true; 
            if (damageDone < player.GetAttack().GetStrength()) weakOccurred = true;  
        }

        Assert.IsTrue(weakOccurred, "Weak hit should occur at least once");
        Assert.IsTrue(critOccurred, "Critical hit should occur at least once");
    }
}


// using System.Collections;
// using UnityEngine;
// using UnityEngine.TestTools;
// using NUnit.Framework;
// using Moq;

// public class AttackUtilsTests
// {
//     private Mock<Entity> attackerMock;
//     private Mock<Entity> defenserMock;
//     private Mock<Health> healthMock;

//     [SetUp]
//     public void Setup()
//     {
//         // Mock attacker Entity
//         attackerMock = new Mock<Entity>();
//         attackerMock.Setup(a => a.GetStrength()).Returns(10);

//         // Mock Health
//         healthMock = new Mock<Health>();
//         healthMock.Setup(h => h.GetDamage(It.IsAny<int>()));

//         // Mock defenser Entity
//         defenserMock = new Mock<Entity>();
//         defenserMock.Setup(d => d.GetHealth()).Returns(healthMock.Object);
//     }

//     [Test]
//     public void Damage_CallsGetDamageWithCeilAbsoluteValue()
//     {
//         // Act
//         AttackUtils.Damage(attackerMock.Object, defenserMock.Object);

//         // Assert
//         // Since CriticalHit is random, we cannot predict exact damage. But we can check it is >= attacker strength
//         healthMock.Verify(h => h.GetDamage(It.Is<int>(d => d >= 5 && d <= 20)), Times.Once);
//     }

//     [Test]
//     public void Damage_AlwaysCallsGetDamage()
//     {
//         // Act
//         AttackUtils.Damage(attackerMock.Object, defenserMock.Object);

//         // Assert
//         healthMock.Verify(h => h.GetDamage(It.IsAny<int>()), Times.Once);
//     }
// }