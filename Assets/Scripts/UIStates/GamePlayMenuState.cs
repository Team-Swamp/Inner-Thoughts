using UnityEngine;
using UnityEngine.Events;

public class GamePlayMenuState : UIBaseState
{
    [SerializeField] private UnityEvent onPause = new UnityEvent();
    [SerializeField] private UnityEvent onPressedResume = new UnityEvent();
    [SerializeField] private UnityEvent onUnpause = new UnityEvent();

    private bool _isPaused;

    protected override void EnterState() => TimeScaleController.SetTimeScale(1);
    
    private void Update() => GetPauseState();

    private void GetPauseState()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && OwningStateMachine.CurrentState is GamePlayMenuState or PauseMenuState)
        {
            Resume();
        }
    }

    public void Resume()
    {
        if (!_isPaused)
        {
            onPause?.Invoke();
            TimeScaleController.SetTimeScale(0);
        }
        else
        {
            onUnpause?.Invoke();
            TimeScaleController.SetTimeScale(1);
        }
        _isPaused = !_isPaused;
    }

    protected override void ExitState() => TimeScaleController.SetTimeScale(0);
}
