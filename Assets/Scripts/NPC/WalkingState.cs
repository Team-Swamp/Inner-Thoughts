using UnityEngine;

public class WalkingState : SmallEnemiesBaseState
{
    [SerializeField] private Waypoint currentWaypoint;
    [SerializeField] private Grid myGrid;
    [SerializeField] private float distanceTreshhold;
    [SerializeField] private float movingSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveVelocity;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
    protected override void EnterState(SmallEnemiesStateMachine enemy)
    {
       if(currentWaypoint == null)
       {
            GetNewWaypoint();
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

    private Waypoint GetNewWaypoint()
    {
        currentWaypoint = myGrid.GetRandomWaypoint();
        return currentWaypoint;
    }


    protected override void UpdateState(SmallEnemiesStateMachine enemy)
    {
        
    }
    
}
