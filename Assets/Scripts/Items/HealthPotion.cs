using System;

public class HealthPotion : Item {
    // public string name = "Potion de soin";
    // public string name { get; private set; } = "Potion de soin";

    public void Effect(Entity entity) {
        int maxHealth = entity.GetHealth().GetMaxHealth();
        int currentHealth = entity.GetHealth().GetCurrentHealth();


        double multiply = maxHealth * 0.5;

        // double product = attacker.GetLevel() * (double)multiply;
        int addHealth = (int)Math.Ceiling(Math.Abs(multiply));

        if (currentHealth + addHealth > maxHealth) {
            entity.GetHealth().SetCurrentHealth(maxHealth);
        } else {
            entity.GetHealth().SetCurrentHealth(currentHealth + addHealth);
        }
    }

}