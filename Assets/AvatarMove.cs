using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarMove : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private string move = "Move";
    [SerializeField] private string rotation = "Rotation";

    private InputAction moveAction;
    private InputAction rotationAction;

    public Vector2 MoveInput { get; private set; }
    public Vector2 RotationInput { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        InputActionMap mapRef = playerControls.FindActionMap(actionMapName);

        moveAction = mapRef.FindAction(move);
        rotationAction = mapRef.FindAction(rotation);

        SubscibeActionValuesToInputEvents();
    }

    private void SubscibeActionValuesToInputEvents()
    {
        moveAction.performed += inputInfo => MoveInput = inputInfo.ReadValue<Vector2>();
        moveAction.canceled += inputInfo => MoveInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }

}
