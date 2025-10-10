    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.SceneManagement;
    using TMPro;

public class MapController : MonoBehaviour
{
    public Player player;

    // public DisplayStat displayPlayerStat;
    // public DisplayStat displayPlayerInventory;

    public TMP_Text playerStatText;
    public TMP_Text playerInventoryText;
    private TMP_Text[] textList = new TMP_Text[2];

    
    void Start()
    {
        player = Player.instance;
        textList[0] = playerStatText;
        textList[1] = playerInventoryText;

        if (playerStatText != null)
        {
            this.InitializeBag(player, playerStatText); 
        }

        if (playerInventoryText != null)
        {
            this.InitializeBag(player, playerInventoryText, player.bag); 
        }
    }

    void FixedUpdate() {
        this.InitializeBag(player, playerStatText);
        this.InitializeBag(player, playerInventoryText, player.bag); 
    }

    public void Save()
    {
        SaveSystem.SavePlayer(player);
    }

    public void Quit()
    {
        Application.Quit();
        // for testing
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void InitializeBag(Player newEntity, TMP_Text newText, Bag bag = null) {
        // player = newEntity;
        // entityText = newText;
        if (bag != null) {
            UpdateDisplayInventory(newText, bag);  // immediate update
        } else {
            UpdateDisplay(newText);
        }
    }

    private void UpdateDisplayInventory(TMP_Text newText, Bag bag) {
        newText.text = $"Attaque spéciale : {player.GetAttack().GetSpecialAttackCount()}\n"
        + $"{player.bag.ToParagraphString()}";
        // newText.text = "Va te faire foutre";
    }

    private void UpdateDisplay(TMP_Text newText) {
        newText.text = $"{player.GetType()}\n" + $"{player.ToParagraphString()}";
    }


}