public class FleePotion : Item {

    public void Effect(Entity entity) {
        System.Random random = new System.Random();
        int randomValue = random.Next(0, 10);
        // int testRandom = 2;

        // 1 chance out of 2 to flee
        if (randomValue % 2 == 0) {
            entity.SetIsInArena(false);
        }
    }

}