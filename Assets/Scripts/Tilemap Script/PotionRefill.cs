using UnityEngine;

public class PotionRefill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // player.bag = new Bag(); // Refill the bag to max
            player.bag.Refill();
            Debug.Log($"AVANT Refill potion, combien d'attaque? {player.GetAttack().GetSpecialAttackCount()}");
            player.GetAttack().SetSpecialAttackCount(player.GetAttack().GetSpecialAttackFixed());
            Debug.Log($"APRES Refill potion, combien d'attaque? {player.GetAttack().GetSpecialAttackCount()}");
            // Optionally: play sound, show UI, etc.
        }
    }
}
