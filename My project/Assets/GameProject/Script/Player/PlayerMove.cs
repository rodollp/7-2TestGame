using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] private PlayerInputHandler input;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkDistance = 0.3f;
    [SerializeField] private Transform cameraRoot;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (status == null)
        {
            status = GetComponent<PlayerStatus>();
        }

        if (input == null)
        {
            input = GetComponent<PlayerInputHandler>();
        }

        if (rb == null)
        {
            Debug.LogError("PlayerMove에 Rigidbody가 없습니다.");
            enabled = false;
            return;
        }

        if (status == null || input == null)
        {
            Debug.LogError("PlayerMove에 필요한 컴포넌트가 없습니다.");
            enabled = false;
            return;
        }

        if (groundCheck == null || cameraRoot == null)
        {
            Debug.LogError("PlayerMove의 GroundCheck 또는 CameraRoot가 연결되지 않았습니다.");
            enabled = false;
        }
    }

    private void Update()
    {
        if (!input.JumpPressed)
        {
            return;
        }

        Jump();
        input.ConsumeJumpInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = input.MoveInput;

        Vector3 camForward = cameraRoot.forward;
        Vector3 camRight = cameraRoot.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * moveInput.y + camRight * moveInput.x;

        rb.linearVelocity = new Vector3(moveDirection.x * status.MoveSpeed, rb.linearVelocity.y, moveDirection.z * status.MoveSpeed);
    }

    private void Jump()
    {
        if (!CheckGround())
        {
            return;
        }

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, status.JumpPower, rb.linearVelocity.z);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(groundCheck.position,Vector3.down,checkDistance,Physics.DefaultRaycastLayers,QueryTriggerInteraction.Ignore);
    }
}