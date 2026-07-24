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

    public event Action OnChangeHp;
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
        OnChangeHp?.Invoke();
        //Debug.Log($"Hp : {CurrentHp}/{MaxHp}"); 이벤트 적용?
    }

    protected override void Die()
    {
        if (IsDead) return;
        base.Die();
        OnDead?.Invoke();
        Destroy(gameObject); // 구조 바꾸기
    }
}