using UnityEngine;

namespace Assets.GameProject.Script.Interface
{
    public interface IWeaponAttack
    {
        void Attack(PlayerAttack playerAttack,WeaponStatus weapon,Transform attacker,IDamageable target);
    }
}
