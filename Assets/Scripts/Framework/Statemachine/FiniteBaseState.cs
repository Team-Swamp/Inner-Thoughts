using UnityEngine;

public abstract class FiniteBaseState : MonoBehaviour
{
    protected FiniteStateMachine Parent;
    public bool IsValidToSwitch { get; protected set; }

    public void SetParent(FiniteStateMachine targetMachine) => Parent = targetMachine;

    public virtual void EnterState(FiniteStateMachine stateMachine) => IsValidToSwitch = false;
    public abstract void UpdateState(FiniteStateMachine stateMachine);
    public abstract void FixedUpdateState(FiniteStateMachine stateMachine);
    public abstract void ExitState(FiniteStateMachine stateMachine);
}
