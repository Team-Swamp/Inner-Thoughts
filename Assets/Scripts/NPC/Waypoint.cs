using System.Collections.Generic;
using UnityEngine;

public sealed class Waypoint : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Grid parentGrid;

    [Header("Settings")]
    [SerializeField] private bool isOccupied;
    [SerializeField] private float connectedWaypointRadius;
    [SerializeField] private Collider2D[] hits = new Collider2D[8];

    [Header("Debug")]
    [SerializeField] private bool drawGizmos;

    private Waypoint _connectedWaypoint;
    private List<Waypoint> _connectedWaypoints = new List<Waypoint>();
    
    private bool _gameStart;

    private void Awake()
    {
        _gameStart = true;
        InitialCollisionCheck();
    }
    
    private void InitialCollisionCheck()
    {
        var hitCount = Physics2D.OverlapBoxNonAlloc(transform.position, transform.localScale / 2, 0, hits);

        if (hitCount <= 1)
        {
            isOccupied = false;
            RefreshconnectedWaypoints();
            return;
        }

        for (int i = 0; i < hitCount; i++)
        {
            if (isOccupied) continue;
            if (hits[i].gameObject == gameObject) continue;
            
            isOccupied = true;
        }
        
        RefreshconnectedWaypoints();
    }
    
    public void SetGrid(Grid grid)
    {
        parentGrid = grid;
        parentGrid.SubscribeToGrid(this);
    }

    public void GetConnectedWaypoint(out Waypoint newWaypoint, out bool isDeadEnd)
    {
        RefreshconnectedWaypoints();

        isDeadEnd = _connectedWaypoints.Count <= 1;
        var randomIndex = Random.Range(0, _connectedWaypoints.Count);
        newWaypoint = _connectedWaypoints[randomIndex];
    }

    private void RefreshconnectedWaypoints()
    {
        var hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, connectedWaypointRadius, hits);
        if (hitCount < 1) return;
        
        for(int i = 0; i < hitCount; i++)
        {
            if (hits[i].gameObject == gameObject) continue;

            if(hits[i].TryGetComponent(out _connectedWaypoint))
            {
                if (_connectedWaypoints.Contains(_connectedWaypoint))
                {
                    if (_connectedWaypoint.isOccupied) _connectedWaypoints.Remove(_connectedWaypoint);
                    continue;
                }

                if (_connectedWaypoint.isOccupied) continue;

                _connectedWaypoints.Add(_connectedWaypoint);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOccupied) return;
        isOccupied = true;
        parentGrid.UnsubscribeFromGrid(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOccupied = false;
        parentGrid.SubscribeToGrid(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        if (!_gameStart)
        {
            InitialCollisionCheck();
        }
        
        if (!isOccupied)
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale / 2);
        }

        if (drawGizmos)
        {
            Gizmos.DrawWireSphere(transform.position, connectedWaypointRadius);
        }
    }
}
