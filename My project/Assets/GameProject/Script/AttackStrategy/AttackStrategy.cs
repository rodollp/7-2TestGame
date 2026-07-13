using Assets.GameProject.Script;
using UnityEngine;

public abstract class AttackStrategy : ScriptableObject
{
    public abstract void Attack(PlayerAttack playerAttack,WeaponStatus wepon,IDamageable target);
    

}
