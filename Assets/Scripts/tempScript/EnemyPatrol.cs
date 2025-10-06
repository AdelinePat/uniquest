using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPatrol : MonoBehaviour
{

    public float speed = 2f;               // Movement speed
    public float moveDistance = 3f;        // How far it moves from the start point

    private Vector3 startPos;
    private SpriteRenderer spriteRenderer;
    private float lastX;                   // To detect direction

    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastX = transform.position.x;
    }

    void Update()
    {
        // PingPong between 0 and moveDistance * 2
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


    // public float speed = 2f;               // Movement speed
    // public float moveDistance = 3f;        // How far it moves from the start point

    // private Vector3 startPos;

    // void Start()
    // {
    //     startPos = transform.position;
    // }

    // void Update()
    // {
    //     // PingPong between 0 and moveDistance * 2
    //     float move = Mathf.PingPong(Time.time * speed, moveDistance * 2) - moveDistance;
    //     transform.position = new Vector3(startPos.x + move, transform.position.y, transform.position.z);


    // }
}


    