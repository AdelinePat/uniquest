using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// public class ElevationEntry : MonoBehaviour
// {

//     public Collider2D[] MountainColliders;

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.tag == "Warrior")
//         {
//             foreach (Collider2D mountain in MountainColliders)
//             {
//                 mountain.enabled = false;
//             }

//             collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
//         }
        
//     }

//      void Start()
//     {

//     }

//     void Update() {

//     }
// }

public class ElevationEntry : MonoBehaviour
{
    public TilemapCollider2D[] mountainColliders;

    public TilemapCollider2D[] boundaryColliders;

    // void Awake()
    // {
    //     collisionTilemaps = new TilemapCollider2D[2];
    //     collisionTilemaps[0] = gameObject.Find("collision-high")?.GetComponent<TilemapCollider2D>();
    //     collisionTilemaps[1] = gameObject.Find("collision-low")?.GetComponent<TilemapCollider2D>();

    //     for (int i = 0; i < collisionTilemaps.Length; i++)
    //     {
    //         if (collisionTilemaps[i] == null)
    //             Debug.LogError($"collisionTilemaps[{i}] not found!");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Warrior entered trigger!");

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