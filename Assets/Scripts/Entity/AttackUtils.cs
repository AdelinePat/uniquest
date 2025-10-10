using System;

public static class AttackUtils {
    public static void Damage(Entity attacker, Entity defenser, System.Random random = null) {

        if(random == null) random = new System.Random();

        double product = Defense(defenser, attacker.GetAttack().GetStrength()) * (double)CriticalHit(random);
        int damage = (int)Math.Ceiling(Math.Abs(product));
        defenser.GetHealth().GetDamage(damage);
    }

    public static void SpecialDamage(Entity attacker, Entity defenser, System.Random random = null) {

        if(random == null) random = new System.Random();

        double product = attacker.GetAttack().GetStrength() * (double)CriticalHit(random);
        int damage = (int)Math.Ceiling(Math.Abs(product));
        defenser.GetHealth().GetDamage(damage);
    }

    private static float CriticalHit(System.Random random) {
        int randomIntInRange = random.Next(0, 100);
         if(randomIntInRange >= 95) {
            return 2f;
         } else if (randomIntInRange == 0) {
            return 0.5f;
         }
         return 1f;
    }

    public static int LevelUp(Entity attacker, Entity defenser) {
        double multiply = defenser.GetLevel() > attacker.GetLevel() ? 3 : 1.5;

        double product = attacker.GetLevel() + (double)multiply;
        int finalLevel = (int)Math.Ceiling(Math.Abs(product));
        return finalLevel;
    }

    private static int Defense(Entity defenser, int damage) {
        int finalDamage = damage - defenser.GetAttack().GetTemporaryDefense() > 0 ? damage - defenser.GetAttack().GetTemporaryDefense() : 1;
        return finalDamage;

    }
}