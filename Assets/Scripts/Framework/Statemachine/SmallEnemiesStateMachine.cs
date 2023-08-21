using UnityEngine;
public class SmallEnemiesStateMachine : FiniteStateMachine
{
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Walking walkingState;

    private new void Update() => base.Update();
}
