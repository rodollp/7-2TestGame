using Assets.GameProject.Script;
using Assets.GameProject.Script.Interface;
using UnityEngine;

public class SwordAttack : IWeaponAttack
{
    public void Attack(PlayerAttack playerAttack, WeaponStatus weapon, Transform attacker, IDamageable target)
    {
        if (target == null) return;
        if (!IsInRange(weapon, attacker, target)) return;

        playerAttack.Damage(weapon, target);
    }

    private bool IsInRange(WeaponStatus weapon, Transform attacker, IDamageable target)
    {
        MonoBehaviour targetObj = target as MonoBehaviour;
        if (targetObj == null) return false;

        float distance = Vector3.Distance(attacker.position,targetObj.transform.position);

        return distance <= weapon.CurrentData.Range;
    }
}