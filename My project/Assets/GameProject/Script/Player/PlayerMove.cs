using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] private PlayerInputHandler input;
    [SerializeField] private Transform cameraTarget;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkDistance = 0.3f;

    private Rigidbody rb;
    private bool isGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (status == null) status = GetComponent<PlayerStatus>();
        if (input == null) input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        if (input.JumpPressed)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = input.MoveInput;

        Vector3 camForward = cameraTarget.forward;
        Vector3 camRight = cameraTarget.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * moveInput.y + camRight * moveInput.x;

        rb.linearVelocity = new Vector3(
            moveDir.x * status.MoveSpeed,
            rb.linearVelocity.y,
            moveDir.z * status.MoveSpeed
        );
    }

    private void Jump()
    {
        if (CheckGround())
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                status.JumpPower,
                rb.linearVelocity.z
            );
        }
    }

    private bool CheckGround()
    {
        isGround = Physics.Raycast(
            groundCheck.position,
            Vector3.down,
            checkDistance,
            Physics.DefaultRaycastLayers,
            QueryTriggerInteraction.Ignore
        );

        return isGround;
    }
}