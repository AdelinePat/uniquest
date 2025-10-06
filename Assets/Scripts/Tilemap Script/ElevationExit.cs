using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElevationExit : MonoBehaviour
{
    public TilemapCollider2D[] mountainColliders;

    public TilemapCollider2D[] boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Warrior entered trigger!");

            foreach (TilemapCollider2D mountain in mountainColliders)
            {
                if (mountain != null)
                    mountain.enabled = true;
            }

            foreach (TilemapCollider2D boundary in boundaryColliders)
            {
                if (boundary != null)
                    boundary.enabled = false;
            }

            var sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = 1;
            else
                Debug.LogWarning($"No SpriteRenderer found on {collision.name}");
        }
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
