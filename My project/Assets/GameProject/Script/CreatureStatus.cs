using Assets.GameProject.Script;
using UnityEngine;

public abstract class CreatureStatus : MonoBehaviour, IDamageable
{
    public int CurrentHp { get; protected set; }
    public int MaxHp { get; protected set; }
    public int AttackPower { get; protected set; }
    public float MoveSpeed { get; protected set; }

    public bool IsDead { get; protected set; }

    public virtual void TakeDamage(int damage)
    {
        if (IsDead) return;

        CurrentHp -= damage;

        if (CurrentHp <= 0)
            Die();
    }

    protected virtual void Die()
    {
        if(IsDead) return;
        IsDead = true;
        CurrentHp = 0;
    }
}