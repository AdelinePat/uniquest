using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

using System;

public class Enemy : Entity {
    public Rigidbody2D rb;

    public float moveDistance = 3f; 

    private Vector3 startPos;
    private SpriteRenderer spriteRenderer;
    private float lastX;

    public Vector3 GetStartPos() {
        return this.startPos;
    }

    public SpriteRenderer GetSpriteRenderer() {
        return this.spriteRenderer;
    }

    public float GetLastX() {
        return this.lastX;
    }

    public void SetStartPos(Vector3 newValue) {
        this.startPos = newValue;
    }

    public void SetSpriteRenderer(SpriteRenderer newValue) {
        this.spriteRenderer = newValue;
    }

    public void SetLastX(float newValue) {
        this.lastX = newValue;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
        !collision.gameObject.GetComponent<Entity>().GetIsInArena())
        {
            collision.gameObject.GetComponent<Entity>().SetIsInArena(true);
            SceneManager.LoadScene("Arena");
        }

        // TODO : GO BACK TO MAP AT THE END OF FIGHT FOR NOW GO BACK WHEN ENEMY HIT US
        if (collision.gameObject.CompareTag("Player") &&
        this.GetIsInArena())
        {
            collision.gameObject.GetComponent<Entity>().SetIsInArena(false);
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Start() {
        this.SetSpeed(2f);
        this.SetArenaSpeed(this.GetSpeed() + 5);
        this.random = new System.Random();
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastX = transform.position.x;
    }
    
    public override void Move() {
        if(!this.GetIsInArena()) {
            float move = Mathf.PingPong(Time.time * this.GetSpeed(), moveDistance * 2) - moveDistance;
            transform.position = new Vector3(startPos.x + move, transform.position.y, transform.position.z);

            float currentX = transform.position.x;
            if (currentX > lastX)
                spriteRenderer.flipX = false; // facing right
            else if (currentX < lastX)
                spriteRenderer.flipX = true;  // facing left

            lastX = currentX;
        }
    }

    void Update() {
        this.Move();
    }

    public void InitializeEnemy(int level)
    {
        int pastLevel = this.GetLevel();
        this.SetSpeed(2f);
        this.SetArenaSpeed(this.GetSpeed() + 5);
        this.SetLevel(level);
        this.UpdateStat(pastLevel);
    }

}