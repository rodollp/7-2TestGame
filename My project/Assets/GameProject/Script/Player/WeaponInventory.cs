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

            // 현재는 테스트용으로 이 무기를 AutoAttack에 연결
            autoAttack.Init(ownedWeapon);

            Debug.Log($"{ownedWeapon.WeaponName} 레벨업! Lv.{ownedWeapon.CurrentLevel}");
            return true;
        }

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null)
            {
                weaponSlots[i] = new WeaponStatus(weaponData);

                // 새로 얻은 무기를 AutoAttack에 연결
                autoAttack.Init(weaponSlots[i]);

                Debug.Log($"{weaponData.WeaponName} 획득! Lv.1");
                return true;
            }
        }

        Debug.Log("무기 인벤토리가 가득 찼습니다.");
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