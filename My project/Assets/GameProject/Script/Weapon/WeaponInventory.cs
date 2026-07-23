using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    [SerializeField] private int maxSlotCount = 3;

    /// <summary>
    /// 플레이어가 보유한 무기를 관리
    /// 
    /// weaponList 
    /// 플레이어가 보유한 무기를 순서대로 저장한다.
    /// 전체 무기를 순회할때만 사용 >> readonly 
    /// 
    /// weaponMap
    /// weaponData를 검색하여서 이미 소유한 무기인지 확인하기 위해 사용
    /// 
    /// </summary>
    private readonly List<WeaponStatus> weaponList = new();
    private readonly Dictionary<WeaponData, WeaponStatus> weaponMap = new();

    /// <summary>
    /// 
    /// Weapons
    /// IReadOnlyList >> 무기 목록 조회만을 위해서 사용
    /// 무기의 추가 및 삭제는 이곳에서만 관리하기 위해서 사용
    /// 자동 공격을 위해서 인벤토리 순회를 위한 작업
    /// 
    /// </summary>
    public IReadOnlyList<WeaponStatus> Weapons => weaponList;
    public int CurrentCount => weaponList.Count;
    public bool IsFull => CurrentCount >= maxSlotCount;


    /// <summary>
    /// 무기의 추가,레벨업,삭제 발생 시 다른 시스템과 연결 시키기 위해 이벤트를 만들었다
    /// </summary>
    public event Action<WeaponStatus> OnWeaponAdded;
    public event Action<WeaponStatus> OnWeaponLevelUp;
    public event Action<WeaponStatus> OnWeaponRemoved;

    /// <summary>
    ///  무기가 있으면 레벨업, 없으면 인벤토리에 추가한다
    /// </summary>
    /// <param name="weaponData">
    /// 추가 하거나 레벨업을 할 무기의 원본 데이터
    /// </param>
    /// <returns>
    /// 추가와 레벨업을 성공했을때 true
    /// 실패시 false
    /// </returns>
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

            weapon.LevelUp(); 

            OnWeaponLevelUp?.Invoke(weapon);
            return true;
        }

        if (IsFull)
        {
            
            return false;
        }

        WeaponStatus newWeapon = new WeaponStatus(weaponData);

        weaponList.Add(newWeapon);
        weaponMap.Add(weaponData, newWeapon);

        

        OnWeaponAdded?.Invoke(newWeapon);
        return true;
    }

    /// <summary>
    /// WeaponData를 이용하여 보유 중인 무기를 찾는다.
    ///
    /// TryFindWeapon을 내부적으로 사용하며,
    /// 성공 여부 대신 WeaponStatus를 반환한다.
    /// </summary>
    /// <param name="weaponData">
    /// 찾을 무기의 원본 데이터.
    /// </param>
    /// <returns>
    /// 찾으면 해당 WeaponStatus,
    /// 찾지 못하면 null.
    /// </returns>
    public WeaponStatus FindWeapon(WeaponData weaponData)
    {
        TryFindWeapon(weaponData, out WeaponStatus weapon);
        return weapon;
    }
    /// <summary>
    /// 플레이어가 해당 무기를 보유하고 있는지 확인한다.
    /// </summary>
    /// <param name="weaponData">
    /// 확인할 무기의 원본 데이터.
    /// </param>
    /// <returns>
    /// 보유 중이면 true,
    /// 보유하지 않았으면 false.
    /// </returns>
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
    /// <summary>
    /// WeaponData를 이용하여
    /// 플레이어가 보유한 WeaponStatus를 찾는다.
    /// </summary>
    /// <param name="weaponData">
    /// 찾을 무기의 원본 데이터.
    /// </param>
    /// <param name="weapon">
    /// 찾기에 성공하면 해당 WeaponStatus를 반환한다.
    /// 실패하면 null이다.
    /// </param>
    /// <returns>
    /// 무기를 찾으면 true,
    /// 찾지 못하면 false.
    /// </returns>
    private bool TryFindWeapon(WeaponData weaponData, out WeaponStatus weapon)
    {
        weapon = null;

        if (weaponData == null) return false;

        return weaponMap.TryGetValue(weaponData, out weapon);
    }
    /// <summary>
    /// 해당 무기를 새로 추가하거나 레벨업할 수 있는지 확인한다.
    /// </summary>
    /// <param name="weaponData">
    /// 확인할 무기의 원본 데이터.
    /// </param>
    /// <returns>
    /// 기존 무기라면 최대 레벨이 아닐 때 true,
    /// 신규 무기라면 인벤토리에 빈 슬롯이 있을 때 true,
    /// 그 외에는 false.
    /// </returns>

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