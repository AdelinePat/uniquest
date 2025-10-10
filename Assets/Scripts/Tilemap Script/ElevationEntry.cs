using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElevationEntry : MonoBehaviour
{
    public TilemapCollider2D[] mountainColliders;

    public TilemapCollider2D[] boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (TilemapCollider2D mountain in mountainColliders)
            {
                if (mountain != null)
                    mountain.enabled = false;
            }

            foreach (TilemapCollider2D boundary in boundaryColliders)
            {
                if (boundary != null)
                    boundary.enabled = true;
            }

            var sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sortingOrder = 15;
            else
                Debug.LogWarning($"No SpriteRenderer found on {collision.name}");
        }
    }
}