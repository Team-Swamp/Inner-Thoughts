using System.Collections.Generic;
using UnityEngine;

public sealed class Grid : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>();

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
}
