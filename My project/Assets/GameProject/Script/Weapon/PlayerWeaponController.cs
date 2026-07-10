using Assets.GameProject.Script;
using Assets.GameProject.Script.Interface;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private WeaponInventory weaponInventory;

    private readonly Dictionary<WeaponStatus, float> attackTimers = new();

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

            Attack(weapon);
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

    private void Attack(WeaponStatus weapon)
    {
        
    }
}