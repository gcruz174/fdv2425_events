using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    
    private bool _isFollowing;
    
    public void StartFollowing()
    {
        _isFollowing = true;
    }
    
    private void Update()
    {
        if (target == null || !_isFollowing) return;
        var targetPosition = target.position;
        targetPosition.y = transform.position.y;
        var currentPosition = transform.position;
        var moveDirection = targetPosition - currentPosition;
        
        if (moveDirection.magnitude < 0.1f) return;
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
