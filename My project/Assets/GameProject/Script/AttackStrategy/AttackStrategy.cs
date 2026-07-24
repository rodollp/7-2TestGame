using Assets.GameProject.Script;
using UnityEngine;

public abstract class AttackStrategy : ScriptableObject
{
    public abstract bool Attack(AttackContext context,WeaponStatus wepon);
    

}
