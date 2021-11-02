using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject _tilePrefab;
    public int sizeX = 20;
    public int sizeY = 20;

    public Tile[,] grid;


    private Dictionary<Tile, Tile[]> neighborDictionary;
    public Tile[] Neighbors(Tile tile)
    {
        return neighborDictionary[tile];
    }

    void Awake()
    {
        grid = new Tile[sizeX, sizeY];
        neighborDictionary = new Dictionary<Tile, Tile[]>();
        GenerateMap(sizeX, sizeY);
    }


    void GenerateMap(int sizeX, int sizeY)
    {
        //Generate Map
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                grid[x, y] = Instantiate(_tilePrefab, new Vector3(x, 0, y), Quaternion.identity).GetComponent<Tile>();
                grid[x, y].Init(x, y);
            }
        }

        //Build Graph from map
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                List<Tile> neighbors = new List<Tile>();
                if (y < sizeY-1)
                    neighbors.Add(grid[x, y + 1]);
                if (x < sizeX-1)
                    neighbors.Add(grid[x + 1, y]);
                if (y > 0)
                    neighbors.Add(grid[x, y - 1]);
                if (x > 0)
                    neighbors.Add(grid[x - 1, y]);

                neighborDictionary.Add(grid[x, y], neighbors.ToArray());
            }
        }
    }

    public void ResetTiles()
    {
        foreach(Tile t in grid)
        {
            t._Color = Color.white;
            t._Text = "";
        }
    }
}
