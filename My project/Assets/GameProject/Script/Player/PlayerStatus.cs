using UnityEngine;

public class PlayerStatus : CreatureStatus
{
    [SerializeField] private PlayerData data;

    public string Name {  get; private set; }
    public int Level { get; private set; }
    public int CurrentExp {  get; private set; }
    public int NeedExp {  get; private set; }

    public float JumpPower { get; private set; }

    private void Awake()
    {
        Name = data.ThisName;
        MaxHp = data.MaxHp;
        AttackPower = data.AttackPower;
        MoveSpeed = data.MoveSpeed;
        JumpPower = data.JumpPower;

        CurrentHp = MaxHp;
    }

    public override void TakeDamage(int damage)
    {
        if (IsDead) return;
        base.TakeDamage(damage);
        Debug.Log($"{Name}ÀÇ Hp : {CurrentHp}/{MaxHp}");
    }

    protected override void Die()
    {
        if (IsDead) return;
        base.Die();
        Debug.Log("»ç¸Á");
    }

}