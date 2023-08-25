public class MainMenuState : UIBaseState
{
    protected override void EnterState() => TimeScaleController.SetTimeScale(0);

    protected override void ExitState(){}
    
}
