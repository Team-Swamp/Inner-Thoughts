using UnityEngine;

public class WalkingState : SmallEnemiesBaseState
{
    [SerializeField] private Waypoint currentWaypoint;
    [SerializeField] private Waypoint lastWaypoint;
    [SerializeField] private Grid myGrid;
    [SerializeField] private float distanceTreshhold;
    [SerializeField] private float movingSpeed;

    [Header("Performance")]
    [SerializeField] private int maxWaypointCallStack = 2;

    private int newWaypointCallStack;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveVelocity;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    protected override void EnterState(SmallEnemiesStateMachine enemy)
    {
       if(currentWaypoint == null)
       {
            currentWaypoint = myGrid.GetRandomWaypoint();
       }
        MoveToWaypoint();
    }

    protected override void ExitState(SmallEnemiesStateMachine enemy) { }
    

    protected override void FixedUpdateState(SmallEnemiesStateMachine enemy) 
    {
        GetDistanceToWaypoint(out var hasReachedWaypoint);
        if (hasReachedWaypoint)
        {
            GetNewWaypoint();
            MoveToWaypoint();
        }
        Debug.DrawLine(transform.position, currentWaypoint.transform.position);
    }

    private void MoveToWaypoint()
    {
        var moveDirection = currentWaypoint.transform.position - transform.position;
        _moveVelocity = moveDirection.normalized * movingSpeed * Time.deltaTime;
        _rigidbody.velocity = _moveVelocity;
    }

    private float GetDistanceToWaypoint(out bool hasReachedWaypoint)
    {
        var distance = currentWaypoint.transform.position - transform.position;
        hasReachedWaypoint = distance.magnitude <= distanceTreshhold;
        return distance.magnitude;
    }

    private void GetNewWaypoint()
    {
        lastWaypoint = currentWaypoint;

        if(newWaypointCallStack >= maxWaypointCallStack)
        {
            currentWaypoint = lastWaypoint;
            newWaypointCallStack = 0;
        }
        else if(currentWaypoint.GetConnectedWaypoint() == lastWaypoint)
        {
            currentWaypoint.GetConnectedWaypoint();
            newWaypointCallStack++;
        }
        else
        {
            currentWaypoint = currentWaypoint.GetConnectedWaypoint();
        }
    }

    protected override void UpdateState(SmallEnemiesStateMachine enemy)
    {
        
    }
    
}
