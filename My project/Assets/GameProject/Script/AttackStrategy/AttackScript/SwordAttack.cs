using Assets.GameProject.Script;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Attack Strategy/Sword Attack")]
public class SwordAttack : AttackStrategy
{
    public override bool Attack(AttackContext context,WeaponStatus weapon)
    {
        List<IDamageable> targets = context.TargetFinder.FindTargetsInRange(context.AttackerTransform.position,weapon.CurrentData.Range);

        if (targets.Count == 0)
            return false;

        foreach (IDamageable target in targets)
        {
            context.PlayerAttack.Damage(weapon,target);
        }

        return true;
    }
}