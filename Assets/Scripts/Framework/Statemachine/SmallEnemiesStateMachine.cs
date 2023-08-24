using UnityEngine;
public class SmallEnemiesStateMachine : FiniteStateMachine
{
    [field: SerializeField] public IdleState idleState { get; private set; }
    [field: SerializeField] public WalkingState walkingState { get; private set; }

    public Rigidbody2D Rigidbody { get; private set; }

    private new void Update() => base.Update();
    private new void Awake()
    {
        base.Awake();
        Rigidbody = GetComponent<Rigidbody2D>();
    }
}
