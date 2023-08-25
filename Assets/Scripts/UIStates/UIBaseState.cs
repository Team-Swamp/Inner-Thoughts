using UnityEngine;
using UnityEngine.Events;

public abstract class UIBaseState : MonoBehaviour
{
    protected UIStateMachineBehavior OwningStateMachine;
    
    [SerializeField] protected UnityEvent onStateEnter;
    [SerializeField] protected UnityEvent onStateExit;

    public void OnEnable()
    {
        InstantiateState();
            
        onStateEnter?.Invoke();
        EnterState();
    }

    public void OnDisable()
    {
        ExitState();
        onStateExit?.Invoke();
    }

    protected void InstantiateState()
    {
        this.Subscribe();
        OwningStateMachine = UIStateMachine.OwningUIStateMachine;
        OwningStateMachine.UpdateStateList();
    }

    protected abstract void EnterState();
    protected abstract void ExitState();
}
