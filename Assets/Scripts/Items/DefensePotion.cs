using System;

public class DefensePotion : Item {
    // public string name = "Potion de soin";
    // public string name { get; private set; } = "Potion de soin";

    public void Effect(Entity entity) {
        
        // int currentHealth = entity.GetHealth().GetCurrentHealth();
        double multiply = entity.GetAttack().GetDefense() * 2f;

        // double product = attacker.GetLevel() * (double)multiply;
        int addDefense = (int)Math.Ceiling(Math.Abs(multiply));
        entity.GetAttack().SetTemporaryDefense(entity.GetAttack().GetTemporaryDefense() + addDefense);
    }

}