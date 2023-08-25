using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStateMachineBehavior : MonoBehaviour
{
    [SerializeField] private UIBaseState firstState;
    [SerializeField] private UIBaseState currentState;
    [SerializeField] private List<UIBaseState> states;
    
    public UIBaseState CurrentState => currentState;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        this.SetOwningStateMachine();
        UIStateMachine.ChangeState(firstState, out currentState);
    }

    public void UpdateStateList()
    {
        if(UIStateMachine.MenuStates.Count > states.Count) states = UIStateMachine.MenuStates;
    }
    
    public void ChangeState(UIBaseState uiBaseState)
    {
        UIStateMachine.ChangeState(uiBaseState, out currentState);
    }
    
    public void QuitGame() => Application.Quit();
}
