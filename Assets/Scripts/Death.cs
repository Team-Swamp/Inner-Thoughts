using UnityEngine;

public sealed class Death : MonoBehaviour
{
    private UIStateMachineBehavior _uiStatemachineBehavior;
    private LosingMenuState _losingMenuState;

    private void Start()
    {
        _uiStatemachineBehavior = FindObjectOfType<UIStateMachineBehavior>();
        _losingMenuState = FindFirstObjectByType<LosingMenuState>(FindObjectsInactive.Include);
    }

    public void GoToLoseScreen()
    {
        _uiStatemachineBehavior.ChangeState(_losingMenuState);
    }
}
