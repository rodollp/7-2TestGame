using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInventoryTest : MonoBehaviour
{
    [SerializeField] private WeaponInventory inventory;
    [SerializeField] private WeaponData testWeapon1;
    [SerializeField] private WeaponData testWeapon2;

    
    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            inventory.AddWeapon(testWeapon1);
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            inventory.AddWeapon(testWeapon2);   
        }
        
    }
}