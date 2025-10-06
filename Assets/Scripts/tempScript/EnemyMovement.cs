using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    public Animator anim;
    private Transform currentPoint;

    public float speed = 1;
    // public int facingDirection = 1;

    // private float horizontal = 5; 
    // private float vertical = 0;

    void Update()
    {

       Vector2 point = currentPoint.position - transform.position;
       if(currentPoint == pointB.transform) {
        rb.linearVelocity = new Vector2(speed, 0);
       } else {
        rb.linearVelocity = new Vector2(-speed, 0);
       }

       if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) {
        currentPoint = pointA.transform;
       }

       if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) {
        currentPoint = pointB.transform;
       }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

}
