public abstract class SmallEnemiesBaseState : FiniteBaseState
{
    #region FiniteBaseState to SmallEnemiesState

    public override void EnterState(FiniteStateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((SmallEnemiesStateMachine) Parent);
    }

    public override void UpdateState(FiniteStateMachine entity) => UpdateState((SmallEnemiesStateMachine)Parent);
    public override void FixedUpdateState(FiniteStateMachine entity) => FixedUpdateState((SmallEnemiesStateMachine)Parent);
    public override void ExitState(FiniteStateMachine entity) => ExitState((SmallEnemiesStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(SmallEnemiesStateMachine enemy);
    protected abstract void UpdateState(SmallEnemiesStateMachine enemy);
    protected abstract void FixedUpdateState(SmallEnemiesStateMachine enemy);
    protected abstract void ExitState(SmallEnemiesStateMachine enemy);

    #endregion
}
