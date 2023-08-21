public class SmallEnemiesStateMachine : FiniteStateMachine
{
    public Idle idleState;
    public Walking walkingState;

    private new void Update() => base.Update();
}
