using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomManger : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<GameObject> enemies;

    [Header("Uninty Event's")]
    [SerializeField] private UnityEvent onRoomCleared = new UnityEvent();
    [SerializeField] private UnityEvent onRoomEntered = new UnityEvent();
    
    private int _enemiesDeathAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.HasTag("Player")) return;
        
        Debug.Log("a");
        onRoomEntered?.Invoke();
    }

    // alle deuren opnen
    // Alle deuren dicht doen
    public void SetDoorsStates(bool targetValue)
    {
        foreach (var door in doors)
        {
            door.SetActive(targetValue);
        }
        Debug.Log("b");
    }
    
    // Enemy die dood gaat
    public void EnemyHasDied()
    {
        Debug.Log("c");
        _enemiesDeathAmount++;
        EveryEnemiesIsDead();
    }

    // Checken of alle enemies dood zijn
    private void EveryEnemiesIsDead()
    {
        if(_enemiesDeathAmount != enemies.Count) return;
        
        Debug.Log("d");
        SetDoorsStates(true);
        onRoomCleared?.Invoke();
    }
}
