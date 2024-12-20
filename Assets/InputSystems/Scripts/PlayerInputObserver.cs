using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> �v���C���[�̓��͂��󂯎��N���X </summary>
[RequireComponent(typeof(PlayerInput))]
public class PlayerInputObserver : MonoBehaviour
{
    [SerializeField] private PlayerInput m_PlayerInput;

    public InputDevice Device => m_PlayerInput.devices.Count != 0 ? m_PlayerInput.devices[0] : null;

    //ToDo : �Ď����� PlayerInput ���Ȃ��Ȃ������ɔ��΂��� Action����������

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
