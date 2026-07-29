using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    // Move Action이 입력되거나 입력이 끝날 때 호출된다.
    public void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
    }

    // Jump Action의 입력 상태가 변경될 때 호출된다.
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            JumpPressed = true;
        }
    }

    // 점프 입력을 사용한 뒤 호출한다.
    public void ConsumeJumpInput()
    {
        JumpPressed = false;
    }
}