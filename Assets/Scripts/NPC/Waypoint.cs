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
    private List<Waypoint> connectedWaypoints = new List<Waypoint>();

    public void SetGrid(Grid grid)
    {
        parentGrid = grid;
        parentGrid.SubscribeToGrid(this);
    }

    public void GetConnectedWaypoint(out Waypoint newWaypoint, out bool isDeadEnd)
    {
        RefreshconnectedWaypoints();

        isDeadEnd = connectedWaypoints.Count <= 1;
        var randomIndex = Random.Range(0, connectedWaypoints.Count);
        newWaypoint = connectedWaypoints[randomIndex];
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
                if (connectedWaypoints.Contains(_connectedWaypoint))
                {
                    if (_connectedWaypoint.isOccupied) connectedWaypoints.Remove(_connectedWaypoint);
                    continue;
                }

                if (_connectedWaypoint.isOccupied) continue;

                connectedWaypoints.Add(_connectedWaypoint);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        if (drawGizmos) Gizmos.DrawWireSphere(transform.position, connectedWaypointRadius);
    }
}
