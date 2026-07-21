using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform cameraRoot;
    [SerializeField] private Transform cameraPivot;

    [SerializeField] private float rotateSpeed = 0.1f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 60f;

    private float pitch;
    private bool canRotate;

    private void Update()
    {
        
        if (Mouse.current == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float yaw = mouseDelta.x * rotateSpeed;
        cameraRoot.Rotate(Vector3.up, yaw, Space.World);

        pitch -= mouseDelta.y * rotateSpeed;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    public void SetRotate(bool value)
    {
        canRotate = value;
    }
}