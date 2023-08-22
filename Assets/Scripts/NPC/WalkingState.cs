using UnityEngine;
using Random = UnityEngine.Random;

public class WalkingState : SmallEnemiesBaseState
{
    private Vector2 _currentWalkingPoint;
    private bool _isDoneWalking;
    protected override void EnterState(SmallEnemiesStateMachine enemy)
    {
        IsValidToSwitch = true;

        var random = Random.Range(0, enemy.WalkPoints.Length);
        _currentWalkingPoint = enemy.WalkPoints[random].position;
        enemy.Agent.SetDestination(_currentWalkingPoint);
    }

    protected override void ExitState(SmallEnemiesStateMachine enemy) { }
    

    protected override void FixedUpdateState(SmallEnemiesStateMachine enemy) { }
    

    protected override void UpdateState(SmallEnemiesStateMachine enemy)
    {
        if (currentPos == targetPos) enemy.SwitchState(enemy.idleState);
    }
    
}
