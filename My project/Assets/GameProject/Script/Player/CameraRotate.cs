using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float rotateSpeed = 120f;

    private void Start()
    {
        // 마우스 커서를 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float yaw = mouseDelta.x * rotateSpeed * Time.deltaTime;

        cameraTarget.Rotate(Vector3.up, yaw, Space.World);
    }
}