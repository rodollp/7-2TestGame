using Assets.GameProject.Script;
using Assets.GameProject.Script.Weapon;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private WeaponInventory weaponInventory;
    [SerializeField] private TargetFinder targetFinder;

    /// <summary>
    /// 각 무기에 대응하는 공격 타이머를 관리한다.
    /// </summary>
    private readonly Dictionary<WeaponStatus, WeaponTimer> attackTimers = new Dictionary<WeaponStatus, WeaponTimer>();

    /// <summary>
    /// AttackStrategy가 공격을 수행하는 데 필요한 공통 객체를 전달한다.
    /// </summary>
    private AttackContext attackContext;

    private void Awake()
    {
        attackContext = new AttackContext(playerAttack,projectileSpawner,targetFinder,transform);
    }

    private void Update()
    {
        CheckWeapons();
    }

    /// <summary>
    /// 인벤토리의 모든 무기를 확인하여
    /// 공격 가능한 무기가 있다면 공격을 수행한다.
    /// </summary>
    private void CheckWeapons()
    {
        foreach (WeaponStatus weapon in weaponInventory.Weapons)
        {
            if (weapon == null)
                continue;

            WeaponTimer timer = GetTimer(weapon);

            timer.UpdateTimer(Time.deltaTime);

            if (!timer.CanAttack(weapon.CurrentData.Cooldown))
                continue;

            if (TryAttack(weapon))
                timer.Reset();
        }
    }

    /// <summary>
    /// 무기에 대응하는 WeaponTimer를 반환한다.
    /// 타이머가 없다면 새로 생성하여 등록한다.
    /// </summary>
    private WeaponTimer GetTimer(WeaponStatus weapon)
    {
        if (!attackTimers.TryGetValue(weapon, out WeaponTimer timer))
        {
            timer = new WeaponTimer();
            attackTimers.Add(weapon, timer);
        }

        return timer;
    }

    /// <summary>
    /// 무기의 AttackStrategy를 사용하여 공격한다.
    /// 공격에 성공하면 true를 반환한다.
    /// </summary>
    private bool TryAttack(WeaponStatus weapon)
    {
        if (weapon == null)
            return false;

        if (weapon.Data == null)
            return false;

        if (weapon.Data.AttackStrategy == null)
            return false;

        return weapon.Data.AttackStrategy.Attack(attackContext, weapon);
    }
}