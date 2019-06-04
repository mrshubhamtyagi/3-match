using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public BGTile tilePrefab;
    public int widht; // X direction
    public int height; // Y direction

    private BGTile[,] bgTiles;

    void Start()
    {
        bgTiles = new BGTile[widht, height];

        BGTileSetup();
    }

    private void BGTileSetup()
    {
        for (int i = 0; i < widht; i++)
        {
            for (int j = 0; j < height; j++)
            {
                BGTile tile = Instantiate(tilePrefab, new Vector2(i, j), Quaternion.identity, transform);
                tile.name = string.Format("{0} , {1}", i, j);
                bgTiles[i, j] = tile;
            }
        }
    }
}
