using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler input;
    [SerializeField] private Transform visual;
    [SerializeField] private float rotateSpeed = 12f;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

        if (input == null) input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        RotateVisual();
    }

    private void RotateVisual()
    {
        Vector2 moveInput = input.MoveInput;

        Vector3 camForward = mainCamera.transform.forward;
        Vector3 camRight = mainCamera.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 dir = camForward * moveInput.y + camRight * moveInput.x;

        if (dir.sqrMagnitude < 0.001f) return;

        Quaternion targetRot = Quaternion.LookRotation(dir);

        visual.rotation = Quaternion.Slerp(visual.rotation,targetRot,rotateSpeed * Time.deltaTime);
    }
}