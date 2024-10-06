using StarterAssets;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument;
    public ThirdPersonController thirdPersonController;
    public FollowCharacter followCharacter;

    private Label _objectCountText;
    private int _ballCount;
    
    private void Start()
    {
        var rootVisualElement = uiDocument.rootVisualElement;
        var turboButton = rootVisualElement.Q<Button>("TurboButton");
        var normalButton = rootVisualElement.Q<Button>("NormalButton");
        var followButton = rootVisualElement.Q<Button>("StartFollowButton");
        _objectCountText = rootVisualElement.Q<Label>("ObjectCountLabel");
        
        turboButton.clickable.clicked += OnClickTurboButton;
        normalButton.clickable.clicked += OnClickNormalButton;
        followButton.clickable.clicked += followCharacter.StartFollowing;
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
        _objectCountText.text = $"Objetos recolectados: {_ballCount}";
    }
}
