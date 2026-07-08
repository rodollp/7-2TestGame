using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInventoryTest : MonoBehaviour
{
    [SerializeField] private WeaponInventory inventory;
    [SerializeField] private WeaponData testWeapon;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            inventory.AddWeapon(testWeapon);
        }
    }
}