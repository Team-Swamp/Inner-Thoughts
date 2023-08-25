using UnityEngine;
using UnityEngine.Events;

public class CreditsMenuState : UIBaseState
{
    [SerializeField] private float duration;
    [Space]
    [SerializeField] private UnityEvent onDuration = new UnityEvent();

    private float _maxDuration;

    protected override void EnterState()
    {
        _maxDuration = duration;
        TimeScaleController.SetTimeScale(1);
    }
    
    private void Update()
    {
        duration -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) || duration <= 0) onDuration?.Invoke();
    }

    protected override void ExitState() => duration = _maxDuration;
}
