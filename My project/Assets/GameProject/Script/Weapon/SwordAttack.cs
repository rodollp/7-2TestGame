using Assets.GameProject.Script;
using Assets.GameProject.Script.Interface;
using UnityEngine;

public class SwordAttack : IWeaponAttack
{

    public void Attack(PlayerAttack playerAttack,WeaponStatus weapon,IDamageable target)
    {
        playerAttack.Damage(weapon, target);
    }
}
