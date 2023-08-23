using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class RoomManger : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<GameObject> enemies;

    [Header("Uninty Event's")]
    [SerializeField] private UnityEvent onRoomCleared = new UnityEvent();
    [SerializeField] private UnityEvent onRoomEntered = new UnityEvent();
    
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
        SetDoorsStates(false);
        onRoomCleared?.Invoke();
    }
}
