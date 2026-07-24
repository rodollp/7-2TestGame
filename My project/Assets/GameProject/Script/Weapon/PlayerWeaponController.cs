using Assets.GameProject.Script;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private WeaponInventory weaponInventory;
    [SerializeField] private TargetFinder targetFinder;

    /// <summary>
    /// WeaponStatus에 있는 쿨타임을 검색하기 위한 Dictionary 사용
    /// </summary>
    private readonly Dictionary<WeaponStatus, float> attackTimers = new();

    /// <summary>
    /// AttackStrategy가 공격을 수행하는 데 필요한
    /// 공통 객체를 전달하는 Context.
    /// PlayerAttack과 ProjectileSpawner를 보관하여
    /// 공격 전략이 PlayerWeaponController를 직접 참조하지 않도록 한다.
    /// </summary>
    private AttackContext attackContext;

    private void Awake()
    {
        attackContext = new AttackContext(playerAttack, projectileSpawner,targetFinder,transform);
    }
    private void Update()
    {
        CheckWeapons();
    }

    /// <summary>
    /// 인벤토리에 있는 모든 무기를 순회하며 공격 가능 여부를 검사한다.
    /// 무기별 쿨타임을 갱신하고,
    /// 공격 가능한 경우 공격을 수행한 뒤 쿨타임을 초기화한다.
    /// </summary>
    private void CheckWeapons()
    {
        foreach (WeaponStatus weapon in weaponInventory.Weapons)
        {
            UpdateTimer(weapon);

            if (!CanAttack(weapon))
                continue;

            if (TryAttack(weapon))
                ResetTimer(weapon);
        }
    }
    /// <summary>
    /// 무기별 공격 쿨타임 관리
    /// 등록이 되면 타이머를 부여해서 시간이 지나게 만든다.
    /// </summary>
    /// <param name="weapon">
    /// 무기의 쿨타임을 알기 위해 WeaponStatus 사용
    /// </param>
    private void UpdateTimer(WeaponStatus weapon)
    {
        if (!attackTimers.ContainsKey(weapon))
            attackTimers[weapon] = 0f;

        attackTimers[weapon] += Time.deltaTime;
    }
    /// <summary>
    /// 등록한 무기의 시간이 설정한 무기의 쿨타임과 동일하면 공격을 할수 있다
    /// </summary>
    /// <param name="weapon">
    /// 무기 쿨타임
    /// </param>
    /// <returns>
    /// 쿨타임이 넘으면 true
    /// 아니면 false
    /// </returns>
    private bool CanAttack(WeaponStatus weapon)
    {
        return attackTimers[weapon] >= weapon.CurrentData.Cooldown;
    }
    /// <summary>
    /// 다시 공격을 하면서 쿨타임이 돌게 해야 하므로 다시 초기화
    /// </summary>
    /// <param name="weapon"></param>
    private void ResetTimer(WeaponStatus weapon)
    {
        attackTimers[weapon] = 0f;
    }

    /// <summary>
    /// targetFinder에 있는 공격범위내에서 가장 가까운 표적 탐색
    /// 대상이 존재하면 무기들의 고유 공격 방식으로 목표를 공격
    /// </summary>
    /// <param name="weapon"></param>
    /// <returns>
    /// target이 없으면 false
    /// 있으면 true
    /// </returns>
    private bool TryAttack(WeaponStatus weapon)
    {
        if (weapon == null)
            return false;

        if (weapon.Data == null)
            return false;

        if (weapon.Data.AttackStrategy == null)
            return false;

        return weapon.Data.AttackStrategy.Attack(attackContext,weapon);
    }
}