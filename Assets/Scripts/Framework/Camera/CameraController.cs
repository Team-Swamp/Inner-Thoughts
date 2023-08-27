using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;
    [SerializeField] private Vector3 offSet;
    
    private void LateUpdate() => transform.position = followTarget.transform.position + offSet;

    public void SetFollowTarget()
    {
        followTarget = FindObjectOfType<PlayerShooting>().gameObject;
    }
}
