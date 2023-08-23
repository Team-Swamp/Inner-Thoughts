using UnityEngine;
using Pathfinding;

public class EnemyFacingDirection : MonoBehaviour
{
    [SerializeField] private AIPath pathAI;

    Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        FacingDirection();
    }

    void FacingDirection()
    {
        direction = pathAI.desiredVelocity;

        transform.right = direction;
    }
}
