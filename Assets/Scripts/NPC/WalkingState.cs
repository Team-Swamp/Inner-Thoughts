using System;
using UnityEngine;

public class WalkingState : SmallEnemiesBaseState
{
    [Header("Grid")]
    [SerializeField] private Waypoint currentWaypoint;
    [SerializeField] private Grid parentGrid; 

    [Header("Settings")]
    [SerializeField] private float distanceTreshhold;
    [SerializeField] private float movingSpeed;

    [Header("Performance")]
    [SerializeField] private int maxWaypointCallStack = 2;

    private int _newWaypointCallStack;
    private Vector2 _moveVelocity;
    private Waypoint _lastWaypoint;
    private Rigidbody2D _rb;

    protected override void EnterState(SmallEnemiesStateMachine enemy)
    {
        _rb = enemy.Rigidbody;

        if(currentWaypoint == null)
        {
            var hit = Physics2D.OverlapBox(transform.position, transform.localScale, 0);
            hit.TryGetComponent(out currentWaypoint);
            _lastWaypoint = currentWaypoint;
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
        _moveVelocity = moveDirection.normalized * (movingSpeed * Time.deltaTime);
        _rb.velocity = _moveVelocity;
    }

    private float GetDistanceToWaypoint(out bool hasReachedWaypoint)
    {
        var distance = currentWaypoint.transform.position - transform.position;
        hasReachedWaypoint = distance.magnitude <= distanceTreshhold;
        return distance.magnitude;
    }

    private void GetNewWaypoint()
    {
        currentWaypoint.GetConnectedWaypoint(out var newWaypoint, out var isDeadEnd);

        if (isDeadEnd)
        {
            currentWaypoint = _lastWaypoint;
        }
        else if (newWaypoint == _lastWaypoint)
        {
            GetNewWaypoint();
        }
        else
        {
            _lastWaypoint = currentWaypoint;
            currentWaypoint = newWaypoint;
        }
    }

    protected override void UpdateState(SmallEnemiesStateMachine enemy) { }
}
