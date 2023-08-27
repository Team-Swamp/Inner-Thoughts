using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class RoomManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<GameObject> enemies;

    [Header("Unity events")]
    [SerializeField] private UnityEvent onRoomCleared = new UnityEvent();
    [SerializeField] private UnityEvent onRoomEntered = new UnityEvent();
    
    private UIStateMachineBehavior _uiStatemachineBehavior;
    private CreditsMenuState _winningState;
    
    public bool IsCleared { get; private set; }
    private int _enemiesDeathAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.HasTag("Player")) return;
        
        onRoomEntered?.Invoke();
    }

    public void SetDoorsStates(bool targetValue)
    {
        foreach (var door in doors)
        {
            door.SetActive(targetValue);
        }
    }

    public void EnemyHasDied()
    {
        _enemiesDeathAmount++;
        EveryEnemiesIsDead();
    }

    private void EveryEnemiesIsDead()
    {
        if(_enemiesDeathAmount != enemies.Count) return;
        
        IsCleared = true;
        onRoomCleared?.Invoke();
        SetDoorsStates(false);
    }

    private void Start()
    {
        _uiStatemachineBehavior = FindObjectOfType<UIStateMachineBehavior>();
        _winningState = FindFirstObjectByType<CreditsMenuState>(FindObjectsInactive.Include);
    }

    public void GoToCredits()
    {
        _uiStatemachineBehavior.ChangeState(_winningState);
    }
}
