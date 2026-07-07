using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : CreatureStatus
{
    [SerializeField] private MonsterData data;


    public event Action OnDead;
    public int Exp { get; private set; }
    public int Gold { get; private set; }

    public string Name {  get; private set; }

    public float AttackCoolDown {get; private set; }
    private void Awake()
    {
        MaxHp = data.MaxHp;
        AttackPower = data.AttackPower;
        MoveSpeed = data.MoveSpeed;
        Name = data.ThisName;
        AttackCoolDown = data.CoolDown;

        Exp = data.Exp;
        Gold = data.Gold;
        CurrentHp = MaxHp;

        
    }

    public override void TakeDamage(int damage)
    {
        if(IsDead) return;
        base.TakeDamage(damage);
        Debug.Log($"Hp : {CurrentHp}/{MaxHp}");
    }

    protected override void Die()
    {
        if (IsDead) return;
        base.Die();
        OnDead?.Invoke();
        Debug.Log("»ç¸Á");
    }
}