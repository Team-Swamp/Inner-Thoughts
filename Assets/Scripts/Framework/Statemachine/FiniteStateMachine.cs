using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiniteStateMachine : MonoBehaviour
{
    [Header("Base FiniteStateMachine")]
    [SerializeField] protected FiniteBaseState startingState;
    [SerializeField] protected FiniteBaseState[] states;
    [SerializeField] protected FiniteBaseState currentState;

    [SerializeField] private float removeStateQueueTime;
    
    private readonly List<FiniteBaseState> _switchStateQueue = new List<FiniteBaseState>();

    protected void Awake()
    {
        SetStatesParent();
    }

    private void Start()
    {
        EnterStartingState();
    }

    protected void Update()
    {
        currentState.UpdateState(this);
    }
    protected void FixedUpdate()
    {
        currentState.FixedUpdateState(this);

        if (!currentState.IsValidToSwitch || _switchStateQueue.Count <= 0) return;
        
        SwitchState(_switchStateQueue[0]);
        _switchStateQueue.Remove(_switchStateQueue[0]);
    }

    private void SetStatesParent()
    {
        foreach (var state in states)
        {
            state.SetParent(this);
        }
    }

    private void EnterStartingState()
    {
        currentState = startingState;
        currentState.EnterState(this);
    }

    /// <summary>
    /// Switch the current targetState to a different one.
    /// Is it valid to switch targetState?
    /// </summary>
    /// <param name="targetState">Give target state to switch into.</param>
    /// <param name="isCalledFromExitState">If the SwitchState is called form a ExitState function, this needs to be true!</param>
    public void SwitchState(FiniteBaseState targetState, bool isCalledFromExitState = false)
    {
        if (!currentState.IsValidToSwitch)
        {
            StartCoroutine(AddStateInQueue(targetState));
            
            if(!_switchStateQueue.Contains(targetState)) return;
            
            Debug.LogWarning("Switching targetState was not valid!!!\n" + currentState);
            return;
        }
        
        if (!isCalledFromExitState) currentState.ExitState(this);
        currentState = targetState;
        targetState.EnterState(this);
    }
    
    private IEnumerator AddStateInQueue(FiniteBaseState queueableState)
    {
        _switchStateQueue.Add(queueableState);
        Debug.Log("TargetState has been added to the state queue\n" + queueableState);

        yield return new WaitForSeconds(removeStateQueueTime);
    
        if (_switchStateQueue.Contains(queueableState)) _switchStateQueue.Remove(queueableState);
    }
}
