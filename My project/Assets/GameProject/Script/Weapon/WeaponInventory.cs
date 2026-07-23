using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private int maxSlotCount = 3;

    private readonly List<WeaponStatus> weaponList = new();
    private readonly Dictionary<WeaponData, WeaponStatus> weaponMap = new();

    public IReadOnlyList<WeaponStatus> Weapons => weaponList;
    public int CurrentCount => weaponList.Count;
    public bool IsFull => CurrentCount >= maxSlotCount;

    public event Action<WeaponStatus> OnWeaponAdded;
    public event Action<WeaponStatus> OnWeaponLevelUp;
    public event Action<WeaponStatus> OnWeaponRemoved;

    public bool AddWeapon(WeaponData weaponData)
    {
        if (weaponData == null) return false;

        WeaponStatus weapon = FindWeapon(weaponData);

        if (weapon != null)
        {
            if (weapon.IsMaxLevel)
            {
                return false;
            }

            weapon.LevelUp(); // 연결? 

            OnWeaponLevelUp?.Invoke(weapon);
            return true;
        }

        if (IsFull)
        {
            // 인벤토리 가득 찼을때 뜨는 이벤트? 텍스트?
            return false;
        }

        WeaponStatus newWeapon = new WeaponStatus(weaponData);

        weaponList.Add(newWeapon);
        weaponMap.Add(weaponData, newWeapon);

        //Debug.Log($"{newWeapon.WeaponName} 획득!"); 

        OnWeaponAdded?.Invoke(newWeapon);
        return true;
    }

    public WeaponStatus FindWeapon(WeaponData weaponData)
    {
        TryFindWeapon(weaponData, out WeaponStatus weapon);
        return weapon;
    }

    public bool ContainsWeapon(WeaponData weaponData)
    {
        return TryFindWeapon(weaponData, out _);
    }

    public bool RemoveWeapon(WeaponData weaponData)
    {
        if (!TryFindWeapon(weaponData, out WeaponStatus weapon))
        {
            // 무기 없으면 리턴
            return false;
        }

        weaponMap.Remove(weaponData);
        weaponList.Remove(weapon);

        // 무기 삭제 이벤트 처리

        OnWeaponRemoved?.Invoke(weapon);
        return true;
    }

    private bool TryFindWeapon(WeaponData weaponData, out WeaponStatus weapon)
    {
        weapon = null;

        if (weaponData == null) return false;

        return weaponMap.TryGetValue(weaponData, out weapon);
    }

    public bool CanAddWeapon(WeaponData weaponData)
    {
        if (weaponData == null) return false;

        WeaponStatus weapon = FindWeapon(weaponData);
        
        if (weapon != null)
        {
            return !weapon.IsMaxLevel;
        }

        return !IsFull;
    }
}