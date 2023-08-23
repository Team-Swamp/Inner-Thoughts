using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Grid parentGrid;
    [SerializeField] private bool isOccupied;

    public bool IsOccupied => isOccupied;

    private void Awake()
    {
        parentGrid = GetComponentInParent<Grid>();
        parentGrid.SubscribeToGrid(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOccupied = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOccupied = false;
    }
}
