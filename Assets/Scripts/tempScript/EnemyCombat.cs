using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
