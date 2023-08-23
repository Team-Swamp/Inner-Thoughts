using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>();

    public void SubscribeToGrid(Waypoint waypoint)
    {
        if (waypoints.Contains(waypoint)) return;
        waypoints.Add(waypoint);
    }

    public Waypoint GetRandomWaypoint()
    {
        var randomIndex = Random.Range(0, waypoints.Count);
        if (waypoints[randomIndex].IsOccupied)
        {
            GetRandomWaypoint();
        }
        return waypoints[randomIndex];
    }
}
