public abstract class BossBaseState : FiniteBaseState
{
    #region FiniteBaseState to BigEnemiesState

    public override void EnterState(FiniteStateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((BossStateMachine) Parent);
    }

    public override void UpdateState(FiniteStateMachine entity) => UpdateState((BossStateMachine)Parent);
    public override void FixedUpdateState(FiniteStateMachine entity) => FixedUpdateState((BossStateMachine)Parent);
    public override void ExitState(FiniteStateMachine entity) => ExitState((BossStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(BossStateMachine boss);
    protected abstract void UpdateState(BossStateMachine boss);
    protected abstract void FixedUpdateState(BossStateMachine boss);
    protected abstract void ExitState(BossStateMachine boss);

    #endregion
}
