using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTester : MonoBehaviour
{
    public Pathfinding _pathfinding;
    public MapGenerator _mapGenerator;
    public GameObject _playerAgentPrefab;

    private Tile _startTile;
    private Tile _endTile;
    private Agent _agent;

    private void Start()
    {
    }

    private void Update()
    {
        HandleInput();
    }

    private void CalculatePath(Tile start, Tile end)
    {
        Queue<Tile> path = _pathfinding.FindPath(_startTile, _endTile);
        if (path == null)
            Debug.LogWarning("Goal not reachable");
        else
        {
            foreach (Tile t in path)
            {
                t._Color = new Color(1, 0.6f, 0);
            }

            _endTile._Color = Color.red;
            _endTile._Text = "End";
            _startTile._Color = Color.cyan;
            _startTile._Text = "Start";
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Tile tileUnderMouse = GetTileUnderMouse();
            if (tileUnderMouse != null && tileUnderMouse._TileType == Tile.TileType.Wall)
            {
                Debug.LogWarning("Can't start or end on Walls!");
                return;
            }

            if (tileUnderMouse != null)
            {
                _startTile = tileUnderMouse;
            }

            RepaintMap();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Tile tileUnderMouse = GetTileUnderMouse();
            if (tileUnderMouse != null && tileUnderMouse._TileType == Tile.TileType.Wall)
            {
                Debug.LogWarning("Can't start or end on Walls!");
                return;
            }


            if (tileUnderMouse != null)
            {
                _endTile = tileUnderMouse;
            }
            RepaintMap();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Tile tileUnderMouse = GetTileUnderMouse();
            if (tileUnderMouse != null)
            {
                tileUnderMouse._TileType = Tile.TileType.Plains;
                RepaintMap();
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            Tile tileUnderMouse = GetTileUnderMouse();
            if (tileUnderMouse != null)
            {
                tileUnderMouse._TileType = Tile.TileType.Wood;
                RepaintMap();
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            Tile tileUnderMouse = GetTileUnderMouse();
            if (tileUnderMouse != null)
            {
                tileUnderMouse._TileType = Tile.TileType.Wall;
                RepaintMap();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Tile t in _mapGenerator.grid)
            {
                t._Text = t._X + ", " + t._Y;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
            RepaintMap();

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (_agent == null)
                _agent = Instantiate(_playerAgentPrefab, _startTile.transform.position, Quaternion.identity).GetComponent<Agent>();
            else
                _agent.transform.position = _startTile.transform.position;

            Queue<Tile> path = _pathfinding.FindPath(_startTile, _endTile);
            _agent.SetPath(path);
        }
    }

    private Tile GetTileUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        bool wasHit = Physics.Raycast(ray, out rayHit, int.MaxValue, LayerMask.GetMask("Tiles"));
        if (wasHit)
            return rayHit.transform.GetComponent<Tile>();
        else
            return null;
    }

    public void RepaintMap()
    {
        _mapGenerator.ResetTiles();
        if (_endTile != null)
        {
            _endTile._Color = Color.red;
            _endTile._Text = "End";
        }
        if (_startTile != null)
        {
            _startTile._Color = Color.green;
            _startTile._Text = "Start";
        }

        if (_startTile != null && _endTile != null)
        {
            CalculatePath(_startTile, _endTile);
        }
    }
}
