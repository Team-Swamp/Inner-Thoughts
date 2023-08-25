using System.Collections.Generic;

public static class UIStateMachine
{
    public static UIStateMachineBehavior OwningUIStateMachine { get; private set; }

    private static List<UIBaseState> _menuStates = new();

    private static UIBaseState _currentMenu;

    public static List<UIBaseState> MenuStates => _menuStates;

    public static void Subscribe(this UIBaseState uiBaseState)
    {
        if(!_menuStates.Contains(uiBaseState)) _menuStates.Add(uiBaseState);
    }

    public static void SetOwningStateMachine(this UIStateMachineBehavior uiStateMachineBehavior)
    {
        OwningUIStateMachine = uiStateMachineBehavior;
    }

    public static void ChangeState(UIBaseState uiBaseState, out UIBaseState newState)
    {
        if (_currentMenu != null && _currentMenu.enabled) _currentMenu.gameObject.SetActive(false);

        _currentMenu = uiBaseState;
        newState = _currentMenu;
        newState.gameObject.SetActive(true);
    }
}
