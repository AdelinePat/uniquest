using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class FightMenu : MonoBehaviour {
    public Button mainButton;
    public GameObject[] subButtons;
    private bool isMenuOpen = false;

    void Start()
    {
        // Hide sub-buttons at start
        foreach (GameObject btn in subButtons)
        {
            // Display.InitText(btn.GetComponent<TMP_Text>(), typeof(DefensePotion), 3);
            btn.SetActive(false);
        }

        // Add listener for the main button
        mainButton.onClick.AddListener(ToggleMenu);
    }

    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;

        foreach (GameObject btn in subButtons)
        {
            btn.SetActive(isMenuOpen);
        }
    }
}