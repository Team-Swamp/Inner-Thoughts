public abstract class BigEnmiesBaseState : BaseState
{
    #region BaseState to BigEnmiesState

    public override void EnterState(StateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((BigEnmiesStateMachine) Parent);
    }

    public override void UpdateState(StateMachine entity) => UpdateState((BigEnmiesStateMachine)Parent);
    public override void FixedUpdateState(StateMachine entity) => FixedUpdateState((BigEnmiesStateMachine)Parent);
    public override void ExitState(StateMachine entity) => ExitState((BigEnmiesStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(BigEnmiesStateMachine enemy);
    protected abstract void UpdateState(BigEnmiesStateMachine enemy);
    protected abstract void FixedUpdateState(BigEnmiesStateMachine enemy);
    protected abstract void ExitState(BigEnmiesStateMachine enemy);

    #endregion
}
