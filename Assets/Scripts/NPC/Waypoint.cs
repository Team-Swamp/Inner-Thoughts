using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Grid parentGrid;

    private void Awake()
    {
        parentGrid = GetComponentInParent<Grid>();
        parentGrid.SubscribeToGrid(this);
    }
}
