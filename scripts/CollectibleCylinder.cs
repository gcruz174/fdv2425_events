using UnityEngine;

public class CollectibleCylinder : MonoBehaviour
{
    public FollowCharacter followCharacter;
    public Transform objectB;
    public Transform objectBTarget;
    
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        objectB.position = objectBTarget.position;
        followCharacter.StartFollowing();
        Destroy(gameObject);
    }
}
