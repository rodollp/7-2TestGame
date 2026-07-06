using UnityEngine;

public class PlayerStatus : CreatureStatus
{
    [SerializeField] private PlayerData data;

    public float JumpPower { get; private set; }

    private void Awake()
    {
        MaxHp = data.MaxHp;
        AttackPower = data.AttackPower;
        MoveSpeed = data.MoveSpeed;
        JumpPower = data.JumpPower;

        CurrentHp = MaxHp;
    }
}