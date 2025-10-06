using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovements : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody2D rb;

    public Animator anim;

    public int facingDirection = 1;

    // private Vector2 movement; 

    void Start()
    {

    }
    

    void Update()
    {
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
}
