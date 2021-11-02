using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private MapGenerator _mapGenerator;

    private void Awake()
    {
        _mapGenerator = FindObjectOfType<MapGenerator>();
    }






    Queue<Tile> FloodFill(Tile start, Tile goal)
    {
        Dictionary<Tile, Tile> nextTileToGoal = new Dictionary<Tile, Tile>();
        Queue<Tile> frontier = new Queue<Tile>();
        List<Tile> visited = new List<Tile>();

        frontier.Enqueue(goal);

        while(frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();

            foreach(Tile neighbor in _mapGenerator.Neighbors(curTile))
            {
                if (visited.Contains(neighbor) == false && frontier.Contains(neighbor) == false)
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        frontier.Enqueue(neighbor);
                        nextTileToGoal[neighbor] = curTile;
                    }
                }
            }
            visited.Add(curTile);
        }

        if (visited.Contains(start) == false)
            return null;

        Queue<Tile> path = new Queue<Tile>();
        Tile curPathTile = start;
        while(curPathTile != goal)
        {
            curPathTile = nextTileToGoal[curPathTile];
            path.Enqueue(curPathTile);
        }

        return path;
    }














    Queue<Tile> Dijkstra(Tile start, Tile goal)
    {
        Dictionary<Tile, Tile> NextTileToGoal = new Dictionary<Tile, Tile>();//Determines for each tile where you need to go to reach the goal. Key=Tile, Value=Direction to Goal
        Dictionary<Tile, int> costToReachTile = new Dictionary<Tile, int>();//Total Movement Cost to reach the tile

        PriorityQueue<Tile> frontier = new PriorityQueue<Tile>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();
            if (curTile == start)
                break;

            foreach (Tile neighbor in _mapGenerator.Neighbors(curTile))
            {
                int newCost = costToReachTile[curTile] + neighbor._Cost;
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        costToReachTile[neighbor] = newCost;
                        int priority = newCost;
                        frontier.Enqueue(neighbor, priority);
                        NextTileToGoal[neighbor] = curTile;
                        neighbor._Text = costToReachTile[neighbor].ToString();
                    }
                }
            }
        }

        //Get the Path

        //check if tile is reachable
        if (NextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }

        Queue<Tile> path = new Queue<Tile>();
        Tile pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        return path;
    }

    Queue<Tile> AStar(Tile start, Tile goal)
    {
        Dictionary<Tile, Tile> NextTileToGoal = new Dictionary<Tile, Tile>();//Determines for each tile where you need to go to reach the goal. Key=Tile, Value=Direction to Goal
        Dictionary<Tile, int> costToReachTile = new Dictionary<Tile, int>();//Total Movement Cost to reach the tile

        PriorityQueue<Tile> frontier = new PriorityQueue<Tile>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();
            if (curTile == start)
                break;

            foreach (Tile neighbor in _mapGenerator.Neighbors(curTile))
            {
                int newCost = costToReachTile[curTile] + neighbor._Cost;
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        costToReachTile[neighbor] = newCost;
                        int priority = newCost + Distance(start, neighbor);//Also use the Distance for the priority so we need to check fewer Tiles
                        frontier.Enqueue(neighbor, priority);
                        NextTileToGoal[neighbor] = curTile;
                        neighbor._Text = costToReachTile[neighbor].ToString();
                    }
                }
            }
        }

        //Get the Path

        //check if tile is reachable
        if (NextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }

        Queue<Tile> path = new Queue<Tile>();
        Tile pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        return path;
    }

    /// <summary>
    /// Finds a path from starttile to endtile
    /// </summary>
    /// <returns>Returns a Queue which contains the Tiles, the player must move.</returns>
    public Queue<Tile> FindPath(Tile start, Tile end)
    {
        switch (_currentAlgorithm)
        {
            case Algorithm.FloodFill:
                return FloodFill(start, end);
            case Algorithm.Dijkstra:
                return Dijkstra(start, end);
            case Algorithm.AStar:
                return AStar(start, end);

        }

        return null;
    }

    /// <summary>
    /// Determines the Manhatten Distance between two tiles. (=How many Tiles the player must move to reach it)
    /// </summary>
    /// <returns>Distance in amount of Tiles the player must move</returns>
    int Distance(Tile t1, Tile t2)
    {
        return Mathf.Abs(t1._X - t2._X) + Mathf.Abs(t1._Y - t2._Y);
    }


    #region unimportant
    public enum Algorithm
    {
        FloodFill = 0,
        Dijkstra = 1,
        AStar = 2
    }

    public Algorithm _currentAlgorithm;
    private void Start()
    {
        TMPro.TMP_Dropdown dropDown = FindObjectOfType<TMPro.TMP_Dropdown>();
        dropDown.onValueChanged.AddListener(OnAlgorithmChanged);
        dropDown.value = PlayerPrefs.GetInt("currentAlgorithm");
    }


    public void OnAlgorithmChanged(int algorithmID)
    {
        _currentAlgorithm = (Algorithm)algorithmID;
        FindObjectOfType<PathTester>().RepaintMap();
        PlayerPrefs.SetInt("currentAlgorithm", (int)algorithmID);
        PlayerPrefs.Save();
    }
    #endregion
}
