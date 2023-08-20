public abstract class BigEnemiesBaseState : FiniteBaseState
{
    #region FiniteBaseState to BigEnemiesState

    public override void EnterState(FiniteStateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((BigEnemiesStateMachine) Parent);
    }

    public override void UpdateState(FiniteStateMachine entity) => UpdateState((BigEnemiesStateMachine)Parent);
    public override void FixedUpdateState(FiniteStateMachine entity) => FixedUpdateState((BigEnemiesStateMachine)Parent);
    public override void ExitState(FiniteStateMachine entity) => ExitState((BigEnemiesStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(BigEnemiesStateMachine enemy);
    protected abstract void UpdateState(BigEnemiesStateMachine enemy);
    protected abstract void FixedUpdateState(BigEnemiesStateMachine enemy);
    protected abstract void ExitState(BigEnemiesStateMachine enemy);

    #endregion
}
