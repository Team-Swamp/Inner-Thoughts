using UnityEngine;
public class SmallEnemiesStateMachine : FiniteStateMachine
{
    [field: SerializeField] public IdleState idleState { get; private set; }
    [field: SerializeField] public WalkingState walkingState { get; private set; }

    private new void Update() => base.Update();
}
