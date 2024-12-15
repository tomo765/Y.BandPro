using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> �v���C���[�̓��͂��󂯎��N���X </summary>
[RequireComponent(typeof(PlayerInput))]
public class PlayerInputReceiver : MonoBehaviour
{
    [SerializeField] private PlayerInput m_PlayerInput;

    void Start()
    {

    }

    private void Update()
    {

    }

    public bool GetButton(string actionName) => m_PlayerInput?.actions[actionName].IsPressed() ?? false;
    public bool GetButtonDown(string actionName) => m_PlayerInput?.actions[actionName].WasPressedThisFrame() ?? false;
    public bool GetButtonUp(string actionName) => m_PlayerInput?.actions[actionName].WasReleasedThisFrame() ?? false;
    public Vector2 GetSthick(string actionName) => m_PlayerInput?.actions[actionName].ReadValue<Vector2>() ?? Vector2.zero;
}
