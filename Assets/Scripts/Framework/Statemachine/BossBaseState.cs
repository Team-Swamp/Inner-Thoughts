using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseState : BaseState
{
    #region BaseState to BigEnmiesState

    public override void EnterState(StateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((BossStateMachine) Parent);
    }

    public override void UpdateState(StateMachine entity) => UpdateState((BossStateMachine)Parent);
    public override void FixedUpdateState(StateMachine entity) => FixedUpdateState((BossStateMachine)Parent);
    public override void ExitState(StateMachine entity) => ExitState((BossStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(BossStateMachine boss);
    protected abstract void UpdateState(BossStateMachine boss);
    protected abstract void FixedUpdateState(BossStateMachine boss);
    protected abstract void ExitState(BossStateMachine boss);

    #endregion
}
