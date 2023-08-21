using UnityEngine;
public class SmallEnemiesStateMachine : FiniteStateMachine
{
    [field: SerializeField] public Idle idleState { get; private set; }
    [field: SerializeField] public Walking walkingState { get; private set; }

    private new void Update() => base.Update();
}
