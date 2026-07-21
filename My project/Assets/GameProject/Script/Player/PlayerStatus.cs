using System;
using UnityEngine;

public class PlayerStatus : CreatureStatus
{
    [SerializeField] private PlayerData data;

    public string Name { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int NeedExp { get; private set; }

    public float JumpPower { get; private set; }

    public float CollectionRange {  get; private set; }

    public event Action OnLevelUp;
    public event Action OnDead;
    public event Action<int,int> OnHpChange;
    private void Awake()
    {
        StartStatus();
    }

    private void StartStatus()
    {
        Name = data.ThisName;
        MaxHp = data.MaxHp;
        AttackPower = data.AttackPower;
        MoveSpeed = data.MoveSpeed;
        JumpPower = data.JumpPower;
        Level = data.StartLevel;
        NeedExp = data.NeedExp;
        CollectionRange = data.CollectionRange;
        CurrentExp = 0;

        CurrentHp = MaxHp;
    }


    public void AddExp(int exp)
    {
        CurrentExp += exp;
        LevelUp();
    }
    private void LevelUp()
    {
        while (CurrentExp >= NeedExp)
        {
            Level += 1;
            CurrentExp -= NeedExp;

            ApplyLevelUpStats();
            OnLevelUp?.Invoke();
        }

    }

    private void ApplyLevelUpStats()
    {
        MaxHp += 5;
        CurrentHp += 5;
        AttackPower += 5;
        NeedExp += Level*10;

        ChangeHp();
    }
    public override void TakeDamage(int damage)
    {
        if (IsDead) return;
        base.TakeDamage(damage);
        ChangeHp();
    }

    protected override void Die()
    {
        if (IsDead) return;
        base.Die();
        OnDead?.Invoke();
        
        
    }

    private void ChangeHp()
    {
        OnHpChange?.Invoke(CurrentHp,MaxHp);
    }
}