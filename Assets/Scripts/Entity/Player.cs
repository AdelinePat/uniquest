using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using System;


public class Player : Entity {

    
    public static Player instance;

    public Rigidbody2D rb;

    public Animator anim;

    public int facingDirection = 1;

    public Bag bag;

    private bool loadedFromSave = false;

    public Player(
        Health health,
        Attack attack,
        Bag bag,
        int level,
        bool isInArena,
        float speed,
        float arenaSpeed,
        int facingDirection) {
            this.health = health;
            this.attack = attack;
            this.bag = bag;
            this.SetLevel(level);
            this.isInArena = isInArena;
            this.SetSpeed(speed);
            this.SetArenaSpeed(arenaSpeed);
            this.facingDirection = facingDirection;
    }

    void Start() {

        if (instance != this) return;
        if (loadedFromSave) return; // skip default setup if loaded

        Debug.Log($"rb assigned? {rb != null}");
        Debug.Log($"anim assigned? {anim != null}");

        Debug.Log($"Speed at start: {this.GetSpeed()}");

        // Default setup for NEW game
        

        this.random = new System.Random();

    }

    public override void Move() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));
        if (rb != null) {
            // rb.linearVelocity = new Vector2(horizontal, vertical) * this.GetSpeed();
            rb.linearVelocity = new Vector2(horizontal, vertical) * this.GetSpeed();
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void Update() {
        this.Move();
    }

     void Awake()
    {
          if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (anim == null) anim = GetComponent<Animator>();

        if (PlayerHolder.LoadedPlayerData != null)
        {
            SaveSystem.LoadPlayer(instance, PlayerHolder.LoadedPlayerData);
            loadedFromSave = true;
            PlayerHolder.LoadedPlayerData = null; // clear after applying
        } else {
            this.ApplyDefaultStats();
            Debug.Log($"Defense : {this.GetAttack().GetDefense()}");
        }
    }

}