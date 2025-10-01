using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovements : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody2D rb;

    // private Vector2 movement; 
    
    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Left/right arrows
        float vertical = Input.GetAxisRaw("Vertical");   // Up/down arrows
        rb.linearVelocity = new Vector2(horizontal, vertical) * this.speed;
        
    }
}
