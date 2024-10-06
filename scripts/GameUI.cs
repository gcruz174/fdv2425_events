using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Button turboButton;
    public Button normalButton;
    public Button followButton;
    public TMP_Text objectCountText;
    public ThirdPersonController thirdPersonController;
    public FollowCharacter followCharacter;
    
    private int _ballCount;
    
    private void Start()
    {
        turboButton.onClick.AddListener(OnClickTurboButton);
        normalButton.onClick.AddListener(OnClickNormalButton);
        followButton.onClick.AddListener(followCharacter.StartFollowing);
    }
    
    private void OnEnable()
    {
        CollectibleSphere.OnCollectibleCollected += OnCollectibleCollected;
    }
    
    private void OnDisable()
    {
        CollectibleSphere.OnCollectibleCollected -= OnCollectibleCollected;
    }
    
    private void OnClickTurboButton()
    {
        thirdPersonController.MoveSpeed = 5f;
        thirdPersonController.SprintSpeed = 10f;
    }
    
    private void OnClickNormalButton()
    {
        thirdPersonController.MoveSpeed = 2f;
        thirdPersonController.SprintSpeed = 5f;
    }
    
    private void OnCollectibleCollected()
    {
        _ballCount++;
        objectCountText.text = $"Objetos recolectados: {_ballCount}";
    }
}
