using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        if (Keyboard.current == null) return;

        ReadMoveInput();
        ReadJumpInput();
    }

    private void LateUpdate()
    {
        // 한 프레임 입력은 다른 스크립트들이 읽은 뒤 초기화
        JumpPressed = false;
    }

    private void ReadMoveInput()
    {
        float h = 0f;
        float v = 0f;

        if (Keyboard.current.aKey.isPressed) h = -1f;
        if (Keyboard.current.dKey.isPressed) h = 1f;
        if (Keyboard.current.wKey.isPressed) v = 1f;
        if (Keyboard.current.sKey.isPressed) v = -1f;

        MoveInput = new Vector2(h, v);

        if (MoveInput.sqrMagnitude > 1f)
            MoveInput = MoveInput.normalized;
    }

    private void ReadJumpInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            JumpPressed = true;
    }
}