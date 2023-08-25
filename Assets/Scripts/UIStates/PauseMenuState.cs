using System;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenuState : UIBaseState
{
    [SerializeField] private GameObject parentPauseMenu;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject optionsScreen;
    
    [SerializeField] private UnityEvent onPause = new UnityEvent();
    [SerializeField] private UnityEvent onUnpause = new UnityEvent();

    private bool _isPaused;

    protected override void EnterState()
    {
        UpdatePauseMenu();
        TimeScaleController.SetTimeScale(0);
    }

    protected override void ExitState()
    {
        UpdatePauseMenu();
        TimeScaleController.SetTimeScale(1);
    }
    
    private void Start() 
    {
        if (pauseScreen) pauseScreen.SetActive(true);
    }

    private void UpdatePauseMenu()
    {
        TogglePauseMenu(_isPaused);
        parentPauseMenu.SetActive(_isPaused);
        optionsScreen.SetActive(false);
        onUnpause?.Invoke();
    }

    public void TogglePauseMenu(bool isPaused)
    {
        pauseScreen.SetActive(!isPaused);
        _isPaused = !isPaused;
    }
}
