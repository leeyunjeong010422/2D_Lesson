using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChecker : MonoBehaviour
{
    [SerializeField] Tilemap Tilemap;
    private void Start()
    {
        for (int y = Tilemap.origin.y; y < Tilemap.origin.y + Tilemap.size.y; y++)
        {
            for (int x = Tilemap.origin.x; x < Tilemap.origin.x + Tilemap.size.x; x++)
            {
                Collider2D collider = Physics2D.OverlapCircle(new Vector2(x, y), 0.4f);

                if (collider != null)
                {

                }

                else
                {

                }
            }
        }
    }
}
