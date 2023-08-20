public abstract class SmallEnmiesBaseState : BaseState
{
    #region BaseState to SmallEnmiesState

    public override void EnterState(StateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((SmallEnemiesStateMachine) Parent);
    }

    public override void UpdateState(StateMachine entity) => UpdateState((SmallEnemiesStateMachine)Parent);
    public override void FixedUpdateState(StateMachine entity) => FixedUpdateState((SmallEnemiesStateMachine)Parent);
    public override void ExitState(StateMachine entity) => ExitState((SmallEnemiesStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(SmallEnemiesStateMachine enemy);
    protected abstract void UpdateState(SmallEnemiesStateMachine enemy);
    protected abstract void FixedUpdateState(SmallEnemiesStateMachine enemy);
    protected abstract void ExitState(SmallEnemiesStateMachine enemy);

    #endregion
}
