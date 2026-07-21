using UnityEngine;

public class StartingWeapon : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private WeaponInventory weaponInventory;

    private void Start()
    {
        if(playerData.StartWeapon == null)
        {
            return;
        }
        weaponInventory.AddWeapon(playerData.StartWeapon);
    }
}
