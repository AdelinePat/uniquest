    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.SceneManagement;
    using TMPro;

public class FightController : MonoBehaviour
{
    public GameObject[] enemies;
    private Player player;
    private Enemy[] enemyEntities;

    public DisplayStat displayPlayerStat;
    public DisplayStat displayEnemyStat;

    public TMP_Text EnemyText;
    public TMP_Text PlayerText;

    public TMP_Text playerStat;
    public TMP_Text enemyStat;

    public float enemyTurnDelay = 1f;

    public bool playerTurn;

    private int countTurn = 0;
    private bool defensePotionActive = false;


    private TMP_Text healText;
    private TMP_Text fleeText;
    private TMP_Text defenseText;
    private TMP_Text specialText;

    public GameObject bagButton;

    public GameObject speciakAttackButton;

    void Start()
    {
        player = Player.instance;
        TMP_Text[] bagTexts = bagButton.GetComponentsInChildren<TMP_Text>(true);
        foreach (TMP_Text t in bagTexts)
        {
            switch (t.name)
            {
                case "HealText":
                    healText = t;
                    break;
                case "FleeText":
                    fleeText = t;
                    break;
                case "DefenseText":
                    defenseText = t;
                    break;
            }
        }

        TMP_Text[] specialAttackText = speciakAttackButton.GetComponentsInChildren<TMP_Text>(true);
        specialText = specialAttackText[1];

        InitText();
        if (displayPlayerStat != null)
        {
            displayPlayerStat.Initialize(player, playerStat); 
        }


        enemyEntities = new Enemy[enemies.Length];
        int playerLevel = player.GetLevel();
        System.Random random = new System.Random();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyEntities[i] = enemies[i].GetComponent<Enemy>();
            int gap = random.Next(-1, 1);
            // int gap = random.Next(-1,3);
            // int finalGap = (playerLevel - gap) > 0 ? playerLevel - gap : 1;
            int enemyLevel = playerLevel + gap > 0 ? playerLevel + gap : 1;
            enemyEntities[i].InitializeEnemy(enemyLevel);

        }

        if (displayEnemyStat != null)
        {
            displayEnemyStat.Initialize(enemyEntities[0], enemyStat); 
        }


        if (player.GetArenaSpeed() >= enemyEntities[0].GetArenaSpeed())
        {
            playerTurn = true;
        }
        else
        {
            playerTurn = false;
        }
        Display.UpdateHealthText(PlayerText, player);
        Display.UpdateHealthText(EnemyText, enemyEntities[0]);

        if (playerTurn == false)
        {
            StartCoroutine(EnemyTurnCoroutine());
        }

    }

    public void PlayerAttack()
    {
        if (!playerTurn) return;

        if (defensePotionActive)
        {
            countTurn++;
            this.ResetTemporaryDefense(player);
        }

        if (enemies.Length > 0 && enemies[0] != null)
        {
            player.GetAttack().NormalAttack(player, enemyEntities[0]);
            Display.UpdateHealthText(EnemyText, enemyEntities[0]);
            this.LevelUp(player, enemyEntities[0]);
            EndFight(IsDead(enemyEntities[0]));
        }

        this.InitText();
        playerTurn = false;
        StartCoroutine(EnemyTurnCoroutine());
    }

    public void PlayerSpecialAttack()
    {
        if (!playerTurn) return;

        if (defensePotionActive)
        {
            countTurn++;
            this.ResetTemporaryDefense(player);
        }

        if (enemies.Length > 0 && enemies[0] != null)
        {
            player.GetAttack().SpecialAttack(player, enemyEntities[0]);
            Display.UpdateHealthText(EnemyText, enemyEntities[0]);
            this.LevelUp(player, enemyEntities[0]);
            EndFight(IsDead(enemyEntities[0]));
        }

        this.InitText();
        playerTurn = false; // enemy's turn next
        StartCoroutine(EnemyTurnCoroutine());
    }

    public void PlayerHeal()
    {

        if (!playerTurn) return;

        if (defensePotionActive)
        {
            countTurn++;
            this.ResetTemporaryDefense(player);
        }

        player.bag.Use(player, typeof(HealthPotion));
        this.InitText();

        playerTurn = false; 
        StartCoroutine(EnemyTurnCoroutine());
    }

    public void PlayerFlee()
    {
        EndFight(IsDead(player));
        if (!playerTurn) return;
        if (defensePotionActive)
        {
            countTurn++;
            this.ResetTemporaryDefense(player);
        }

        player.bag.Use(player, typeof(FleePotion));
        EndFight(IsDead(player));

        this.InitText();
        playerTurn = false;
        StartCoroutine(EnemyTurnCoroutine());
    }


    public void PlayerDefense()
    {
        if (!playerTurn && defensePotionActive) return;

        player.bag.Use(player, typeof(DefensePotion));
        countTurn++;
        this.ResetTemporaryDefense(player);
        defensePotionActive = true;

        this.InitText();
        playerTurn = false; 

        StartCoroutine(EnemyTurnCoroutine());
    }

    private IEnumerator EnemyTurnCoroutine()
    {
        yield return new WaitForSeconds(enemyTurnDelay);

        if (enemies.Length > 0 && enemies[0] != null)
        {
            enemyEntities[0].GetAttack().NormalAttack(enemyEntities[0], player);
            Display.UpdateHealthText(PlayerText, player);
            EndFight(IsDead(player));
        }

        playerTurn = true;
    }

    private bool IsDead(Entity entity)
    {
        return (entity.GetHealth().GetCurrentHealth() <= 0) ? true : false;
    }

    private void LevelUp(Entity attacker, Entity defenser)
    {
        if (this.IsDead(defenser))
        {
            int finalLevel = AttackUtils.LevelUp(attacker, defenser);
            int currentLevel = attacker.GetLevel();
            attacker.SetLevel(finalLevel);
            attacker.UpdateStat(currentLevel);
        }
    }

    private void EndFight(bool death)
    {
        if (death || !player.GetIsInArena())
        {
            player.SetIsInArena(false);
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void ResetTemporaryDefense(Entity entity)
    {
        if (this.countTurn % 3 == 0)
        {
            entity.GetAttack().SetTemporaryDefense(entity.GetAttack().GetDefense());
            this.defensePotionActive = false;
        }

    }

    public void InitText()
    {

        // TMP_Text healText = GameObject.Find("HealText").GetComponent<TMP_Text>();
        Display.UpdateItemText(healText, typeof(HealthPotion), player.bag.healthCount);

        // TMP_Text fleeText = GameObject.Find("FleeText").GetComponent<TMP_Text>();
        Display.UpdateItemText(fleeText, typeof(FleePotion), player.bag.fleeCount);

        // TMP_Text defenseText = GameObject.Find("DefenseText").GetComponent<TMP_Text>();
        Display.UpdateItemText(defenseText, typeof(DefensePotion), player.bag.defenseCount);

        Display.UpdateItemText(specialText, typeof(Attack), player.GetAttack().GetSpecialAttackCount());
    }    
}