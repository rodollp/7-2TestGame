using Assets.GameProject.Script;
using UnityEngine;

public abstract class AttackStrategy : ScriptableObject
{
    public abstract void Attack(AttackContext context,WeaponStatus wepon,IDamageable target);
    

}
