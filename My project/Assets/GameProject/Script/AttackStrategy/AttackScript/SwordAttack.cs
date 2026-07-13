using Assets.GameProject.Script;
using UnityEngine;

[CreateAssetMenu]
public class SwordAttack : AttackStrategy
{
    public override void Attack(PlayerAttack playerAttack, WeaponStatus wepon, IDamageable target)
    {
        playerAttack.Damage(wepon, target);
    }
}
