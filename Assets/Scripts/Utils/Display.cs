using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Display : MonoBehaviour
{
    public static Display Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public static void UpdateHealthText(TMP_Text TextObject, Entity entity)
    {
        if (TextObject != null)
        {
            TextObject.text = $"HP: {entity.GetHealth().GetCurrentHealth()} / {entity.GetHealth().GetMaxHealth()}";
        }
    }

    public static void UpdateItemText(TMP_Text TextObject, System.Type potionType, int count)
    {   
        string text = "Potion";

        text = (potionType == typeof(Attack)) ? "Attaque Spéciale" : "Potion";

        if (count > 1)
        {
            text = (potionType == typeof(Attack)) ? "Attaques Spéciales" : "Potions";
        }

        if (potionType == typeof(HealthPotion))
        {
            TextObject.text = $"{count} {text} de soin";
        }

        if (potionType == typeof(FleePotion))
        {
            TextObject.text = $"{count} {text} de fuite";
        }

        if (potionType == typeof(DefensePotion))
        {
            TextObject.text = $"{count} {text} de défense";
        }

        if (potionType == typeof(Attack))
        {
            TextObject.text = $"{count} {text}";
        }
        // if (TextObject != null)
        // {
        //     TextObject.text = $"HP: {entity.GetHealth().GetCurrentHealth()} / {entity.GetHealth().GetMaxHealth()}";
        // }
    }

    public static void InitText(TMP_Text textObject, System.Type potionType, int count = 3)
    {
        Display.UpdateItemText(textObject, potionType, count);
    }
}