using Assets.GameProject.Script;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private WeaponInventory weaponInventory;
    [SerializeField] private TargetFinder targetFinder;

    private readonly Dictionary<WeaponStatus, float> attackTimers = new();

    private AttackContext attackContext;
    private void Awake()
    {
        attackContext = new(playerAttack, projectileSpawner);
    }
    private void Update()
    {
        CheckWeapons();
    }

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

    private void UpdateTimer(WeaponStatus weapon)
    {
        if (!attackTimers.ContainsKey(weapon))
            attackTimers[weapon] = 0f;

        attackTimers[weapon] += Time.deltaTime;
    }

    private bool CanAttack(WeaponStatus weapon)
    {
        return attackTimers[weapon] >= weapon.CurrentData.Cooldown;
    }

    private void ResetTimer(WeaponStatus weapon)
    {
        attackTimers[weapon] = 0f;
    }

    private bool TryAttack(WeaponStatus weapon)
    {
        IDamageable target = targetFinder.FindNearestTarget(transform.position,weapon.CurrentData.Range);

        if (target == null)
            return false;

        weapon.Data.AttackStrategy.Attack(attackContext,weapon,target);

        return true;
    }
}