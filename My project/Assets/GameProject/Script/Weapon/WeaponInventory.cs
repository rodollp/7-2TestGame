using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private int maxSlotCount = 3;
    [SerializeField] private AutoAttack autoAttack;

    private WeaponStatus[] weaponSlots;

    private void Awake()
    {
        weaponSlots = new WeaponStatus[maxSlotCount];

        if (autoAttack == null)
            autoAttack = GetComponent<AutoAttack>();
    }

    public bool AddWeapon(WeaponData weaponData)
    {
        if (weaponData == null) return false;

        WeaponStatus ownedWeapon = FindWeapon(weaponData);

        if (ownedWeapon != null)
        {
            ownedWeapon.LevelUp();

            
            autoAttack.Init(ownedWeapon);

            Debug.Log($"{ownedWeapon.WeaponName} ·¹º§¾÷! Lv.{ownedWeapon.CurrentLevel}");
            return true;
        }

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null)
            {
                weaponSlots[i] = new WeaponStatus(weaponData);

                
                autoAttack.Init(weaponSlots[i]);

                Debug.Log($"{weaponData.WeaponName} È¹µæ! Lv.1");
                return true;
            }
        }

        Debug.Log("¹«±â ÀÎº¥Åä¸®°¡ °¡µæ Ã¡½À´Ï´Ù.");
        return false;
    }

    private WeaponStatus FindWeapon(WeaponData weaponData)
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null) continue;

            if (weaponSlots[i].Data == weaponData)
                return weaponSlots[i];
        }

        return null;
    }
}