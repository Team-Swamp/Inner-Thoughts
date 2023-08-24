using System.Collections.Generic;
using UnityEngine;

public sealed class Waypoint : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private Grid parentGrid;
    [SerializeField] private bool isOccupied;

    [Header("Settings")]
    [SerializeField] private float connectedWaypointRadius;
    [SerializeField] private Collider2D[] hits = new Collider2D[7];
    [SerializeField] private List<Waypoint> connectedWaypoints = new List<Waypoint>();

    [Header("Debug")]
    [SerializeField] private bool drawGizmos;

    private Waypoint connectedWaypoint;

    private void Awake()
    {
        parentGrid = GetComponentInParent<Grid>();
        parentGrid.SubscribeToGrid(this);
    }

    public Waypoint GetConnectedWaypoint()
    {
        RefreshconnectedWaypoints();
        var randomIndex = Random.Range(0, connectedWaypoints.Count);
        return connectedWaypoints[randomIndex];
    }

    private void RefreshconnectedWaypoints()
    {
        var hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, connectedWaypointRadius, hits);
        if (hitCount < 1) return;
        
        for(int i = 0; i < hitCount; i++)
        {
            if (hits[i].gameObject == gameObject) continue;

            if(hits[i].TryGetComponent(out connectedWaypoint))
            {
                if (connectedWaypoints.Contains(connectedWaypoint))
                {
                    if (connectedWaypoint.isOccupied) connectedWaypoints.Remove(connectedWaypoint);
                    continue;
                }

                if (connectedWaypoint.isOccupied) continue;

                connectedWaypoints.Add(connectedWaypoint);
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
