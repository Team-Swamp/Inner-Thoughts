using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class Grid : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>();
    
    [Header("Grid Creation")]
    [SerializeField] private Waypoint waypointPrefab;
    [SerializeField] private Vector2 gridSize;
    [SerializeField] private bool createGrid;
    
    private Vector2 initPosition;
    private Vector2 safeZone;
    private Vector2 waypointAmount;
    private bool hasUpdatedGrid;
    private int waypointIndex;

    private void Awake()
    {
        createGrid = false;
        if (waypoints.Count <= 0)
        {
            CreateGrid();
        }
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
        waypointAmount.x = (int)Mathf.Abs(gridSize.x);
        waypointAmount.y = (int)Mathf.Abs(gridSize.y);
    }

    private void InitPosition()
    {
        ResetXPosition();
        ResetYPosition();
    }

    private void ResetXPosition()
    {
        initPosition.x = -(gridSize.x - 1) / 2;
        safeZone.x = -initPosition.x - initPosition.x + 1;
    }

    private void ResetYPosition()
    {
        initPosition.y = (gridSize.y - 1) / 2;
        safeZone.y = initPosition.y - -initPosition.y + 1;
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
        for (int i = 0; i < waypointAmount.y; i++)
        {
            var newWaypoint = Instantiate(waypointPrefab, initPosition, transform.rotation);
            newWaypoint.transform.parent = transform;
            newWaypoint.transform.localPosition = initPosition;
            newWaypoint.SetGrid(this);
            newWaypoint.name += $"{++waypointIndex}";
            initPosition.y -= safeZone.y / waypointAmount.y;
        }
    }

    private void CreateGrid()
    {
        waypointIndex = 0;
        CalculateWaypoints();
        DeleteGrid();
        InitPosition();
        
        for (int i = 0; i < waypointAmount.x; i++)
        {
            CreateLine();
            initPosition.x += safeZone.x / waypointAmount.x;
        }
    }

    private void OnDrawGizmos()
    {
        CalculateWaypoints();
        
        if (createGrid)
        {
            CreateGrid();
            createGrid = false;
        }

        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
