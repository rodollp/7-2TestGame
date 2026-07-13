using Assets.GameProject.Script;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Attack Strategy/Sword Attack")]
public class SwordAttack : AttackStrategy
{
    public override void Attack(
        AttackContext context,
        WeaponStatus weapon,
        IDamageable target)
    {
        context.PlayerAttack.Damage(weapon, target);
    }
}