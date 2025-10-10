using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DisplayStat : MonoBehaviour {
    public GameObject entityGameObject;
    public TMP_Text entityText;
    public Entity entity;

    public void Initialize(Entity newEntity, TMP_Text newText) {
        entity = newEntity;
        entityText = newText;
        UpdateDisplay();  // immediate update
    }

    void Start() {
        if(entityGameObject != null) {
            entity = entityGameObject.GetComponent<Entity>();
        } else {
            return;
        }
    }

    void Update() {
        if (entity != null && entityText != null) {
            UpdateDisplay();
        }
    }

    private void UpdateDisplay() {
        entityText.text = $"{entity.GetType()}\n" + $"{entity.ToParagraphString()}";
    }

}