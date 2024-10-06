using System;
using StarterAssets;
using UnityEngine;

public class CollectibleSphere : MonoBehaviour
{
    public bool slowsPlayer;
    
    public static event Action OnCollectibleCollected;
    
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        OnCollectibleCollected?.Invoke();
        Destroy(gameObject);
        if (slowsPlayer)
        {
            var thirdPersonController = other.GetComponent<ThirdPersonController>();
            thirdPersonController.MoveSpeed *= 0.5f;
            thirdPersonController.SprintSpeed *= 0.5f;
        }
    }
}
