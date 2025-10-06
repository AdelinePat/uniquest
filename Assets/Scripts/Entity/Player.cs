using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Entity {
    public Rigidbody2D rb;

    public Animator anim;

    public int facingDirection = 1;


    public override void attack(GameObject target) {
        Debug.Log("le joueur attaque");
        target.GetComponent<Enemy>().getHealth().getDamage(this.getStrength());
    }

    void Start() {
        this.setSpeed(5f);
        Health health = new Health(20, 20, 0);
        this.setHealth(health);
        this.setStrength(2);
        this.getHealth().setDefense(0);
    }

    public override void move() {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Left/right arrows
        float vertical = Input.GetAxisRaw("Vertical");   // Up/down arrows


        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));
        rb.linearVelocity = new Vector2(horizontal, vertical) * this.getSpeed();
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void Update() {
        this.move();
    }


}