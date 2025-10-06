using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnBasedCombat : MonoBehaviour
{
    // [SerializeField] GameObject player;
    // [SerializeField] GameObject enemy;

    // // #TODO Get these value from gameobject entity DIRECTLY not set them here!!!!!
    // [SerializeField] int playerHealth = 10;
    // [SerializeField] int maxPlayerHealth = 10;

    // [SerializeField] int enemyHealth = 10;
    // [SerializeField] int maxEnemyHealth = 10;

    // [SerializeField] TextMeshProUGUI playerHealthText;
    // [SerializeField] TextMeshProUGUI enemyHealthText;
    // // [SerializeField] Button attackButton;

    // private bool playerTurn = true;

    // private Vector2 playerStartPosition;
    // private Vector2 enemyStartPosition;

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     playerStartPosition = player.transform.position;
    //     enemyStartPosition = enemy.transform.position;

    //     UpdateUI();

    //     playerTurn = true;

    //     attackButton.onClick.addListener(PlayerAttack);
    // }

    // void PlayerAttack() {
    //     if(!playerTurn) {
    //         return;
    //     }

    //     StartCoroutine(DoAttack(player, enemy, () => {
    //         enemyHealth -= 2;

    //         if (enemyHealth <= 0) {
    //             enemyHealth = 0;
    //             UpdateUI();
    //             attackButton.interactable = false;
    //             Debug.Log("Enemy defeated!");
    //             return;
    //         }

    //         playerTurn = false;
    //         UpdateUI();
    //         Invoke(nameof(EnemyAttack), 1f);
    //     }));
    // }

    // void EnemyAttack() {

    //     StartCoroutine(DoAttack(player, enemy, () => {
    //         playerHealth -= 1;

    //         if (playerHealth <= 0) {
    //             playerHealth = 0;
    //             UpdateUI();
    //             attackButton.interactable = false;
    //             Debug.Log("Player defeated!");
    //             return;
    //         }

    //         playerTurn = true;
    //         UpdateUI();
    //     }));
    // }

    // IEnumerator DoAttack(GameObject attacker, GameObject target, System.Action onComplete) {
    //     vector2 attackerStart = (attacker == player) ? playerStartPosition : enemyStartPosition;
    //     vector2 targetStart = (targe == player) ? playerStartPosition: enemyStartPosition;

    //     vector2 attackpos = attackerStart + (targetStart - attackerStart).normalized * 0.5f;
    //     vector2 hitPushPos = targetStart + (targetStart - attackerStart).normalized * 0.3f;

    //     yield return MoveOverTime(attacker, attackerStart, attackPos, 0.1f);

    //     yield return MoveOverTime(attacker, attackerPos, attackerStart, 0.1f);

    //     yield return MoveOverTime(target, targetStart, hitPushpos, 0.05f);

    //     yield return MoveOverTime(target, hitPushPos, targetStart, 0.1f);

    //     onComplete?.Invoke(); 
    // }

    // IEnumarator MoveoverTime(GameObject obj, Vector2 startPos, Vector2 endPosition, float duration) {
    //     float elapsed = 0f;
    //     while (elapsed < duration) {
    //         obj.transform.position = vector2.Lerp(startPos, endPosition, elapsed / duration);
    //         elapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     obj.transform.position = endPosition;
    // }

    // void UpdateUI() {
    //     playerHealthText.text = playerHealth + "/" + maxPlayerHealth;
    //     enemyHealthText.text = enemyHealth + "/" + maxEnemyHealth;
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
