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

    public float CollectionRange { get; private set; }

    public event Action OnLevelUp;
    public event Action OnDead;
    public event Action<int, int> OnHpChange;
    public event Action<int, int> OnExpChange;
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
        OnExpChange?.Invoke(CurrentExp, NeedExp);
    }
    private void LevelUp()
    {
        while (CurrentExp >= NeedExp)
        {
            Level++;
            CurrentExp -= NeedExp;
            NeedExp += Level * 10;

            OnLevelUp?.Invoke();
            OnExpChange?.Invoke(CurrentExp,NeedExp);
        }

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
    public void ApplyStatUpgrade(PlayerStatType statType, float value)
    {
        switch (statType)
        {
            case PlayerStatType.MaxHp:
                {
                    int amount = Mathf.RoundToInt(value);
                    MaxHp += amount;
                    CurrentHp += amount;
                    ChangeHp();
                    break;
                }
            case PlayerStatType.AttackPower:
                {
                    AttackPower += Mathf.RoundToInt(value);
                    break;
                }
            case PlayerStatType.MoveSpeed:
                {
                    MoveSpeed += value;
                    break;
                }
            case PlayerStatType.JumpPower:
                {
                    JumpPower += value;
                    break;
                }
            case PlayerStatType.CollectionRange:
                {
                    CollectionRange += value;
                    break;
                }
        }
    }
    private void ChangeHp()
    {
        OnHpChange?.Invoke(CurrentHp, MaxHp);
    }
}