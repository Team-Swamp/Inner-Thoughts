using System.Collections.Generic;
using UnityEngine;

public sealed class Grid : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>();
    
    [Header("Grid Creation")]
    [SerializeField] private Waypoint waypointPrefab;
    [SerializeField] private Vector2 gridSize;
    [SerializeField] private float safeZonePadding;
    [SerializeField] private bool createGrid;
    [SerializeField] private bool clearGrid;
    
    private GameObject _waypointsParent;
    private Vector2 _initPosition;
    private Vector2 _safeZone;
    private Vector2 _waypointAmount;
    private bool _hasUpdatedGrid;
    private int _waypointIndex;

    private void Awake()
    {
        createGrid = false;
        if (waypoints.Count <= 0) CreateGrid();
    }

    public void SubscribeToGrid(Waypoint waypoint)
    {
        if (waypoints.Contains(waypoint)) return;
        waypoints.Add(waypoint);
    }

    public void UnsubscribeFromGrid(Waypoint waypoint)
    {
        if (!waypoints.Contains(waypoint)) return;
        waypoints.Remove(waypoint);
    }

    public Waypoint GetRandomWaypoint()
    {
        var randomIndex = Random.Range(0, waypoints.Count);
        return waypoints[randomIndex];
    }

    private void CalculateWaypoints()
    {
        _waypointAmount.x = (int)Mathf.Abs(gridSize.x);
        _waypointAmount.y = (int)Mathf.Abs(gridSize.y);
    }

    private void InitPosition()
    {
        ResetXPosition();
        ResetYPosition();
    }

    private void ResetXPosition()
    {
        _initPosition.x = -(gridSize.x - 1) / 2;
        _safeZone.x = -_initPosition.x - _initPosition.x + safeZonePadding;
    }

    private void ResetYPosition()
    {
        _initPosition.y = (gridSize.y - 1) / 2;
        _safeZone.y = _initPosition.y - -_initPosition.y + safeZonePadding;
    }

    private void DeleteGrid()
    {
        waypoints.Clear();

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private void CreateLine()
    {
        ResetYPosition();
        for (int i = 0; i < _waypointAmount.y; i++)
        {
            var newWaypoint = Instantiate(waypointPrefab, transform.position, transform.rotation);
            newWaypoint.transform.parent = _waypointsParent.transform;
            newWaypoint.transform.localPosition = _initPosition;
            newWaypoint.SetGrid(this);
            newWaypoint.name += $"{++_waypointIndex}";
            _initPosition.y -= _safeZone.y / _waypointAmount.y;
        }
    }
    
    private void CreateWaypointsParent()
    {
        if (_waypointsParent != null) return;

        _waypointsParent = new GameObject("WaypointParent");
        _waypointsParent.transform.parent = transform;
        _waypointsParent.transform.localPosition = Vector3.zero;
    }

    private void CreateGrid()
    {
        _waypointIndex = 0;
        DeleteGrid();
        CreateWaypointsParent();
        CalculateWaypoints();
        InitPosition();
        
        for (int i = 0; i < _waypointAmount.x; i++)
        {
            CreateLine();
            _initPosition.x += _safeZone.x / _waypointAmount.x;
        }
    }


    private void OnDrawGizmos()
    {
        CalculateWaypoints();

        if (createGrid)
        {
            createGrid = false;
            CreateGrid();
        }

        if (clearGrid)
        {
            clearGrid = false;
            DeleteGrid();
        }

        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
