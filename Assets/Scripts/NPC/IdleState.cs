using UnityEngine;

public class IdleState : SmallEnemiesBaseState
{
    [SerializeField, Range(0, 30)] private float waitTime;

    private float _currentWaitTime;

    protected override void EnterState(SmallEnemiesStateMachine enemy)
    {
        IsValidToSwitch = true;

        _currentWaitTime = waitTime;
    }

    protected override void ExitState(SmallEnemiesStateMachine enemy) { }
    

    protected override void FixedUpdateState(SmallEnemiesStateMachine enemy)
    {
        _currentWaitTime -= Time.deltaTime;

        if (_currentWaitTime <= 0) enemy.SwitchState(enemy.walkingState);
    }

    protected override void UpdateState(SmallEnemiesStateMachine enemy) { }
    
}
