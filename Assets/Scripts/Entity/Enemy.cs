using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Entity {
    public Rigidbody2D rb;

    // public Animator anim;
    public float moveDistance = 3f;        // How far it moves from the start point

    private Vector3 startPos;
    private SpriteRenderer spriteRenderer;
    private float lastX;   

    public override void attack(GameObject target) {
        Debug.Log("l'ennemi attaque");
        target.GetComponent<Player>().getHealth().getDamage(this.getStrength());
    }

    void Start() {
        this.setSpeed(2f);
        Health health = new Health(20, 20, 0);
        this.setHealth(health);
        this.setStrength(2);
        this.getHealth().setDefense(0);

        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastX = transform.position.x;
    }
    
    public override void move() {
        float move = Mathf.PingPong(Time.time * speed, moveDistance * 2) - moveDistance;
        transform.position = new Vector3(startPos.x + move, transform.position.y, transform.position.z);

        // Detect direction and flip sprite accordingly
        float currentX = transform.position.x;
        if (currentX > lastX)
            spriteRenderer.flipX = false; // facing right
        else if (currentX < lastX)
            spriteRenderer.flipX = true;  // facing left

        lastX = currentX;
    }

    // void Flip()
    // {
    //     facingDirection *= -1;
    //     transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    // }

    void Update() {
        this.move();
    }

}