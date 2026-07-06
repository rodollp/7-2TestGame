using UnityEngine;

public class MonsterStatus : CreatureStatus
{
    [SerializeField] private MonsterData data;

    public int Exp { get; private set; }
    public int Gold { get; private set; }

    public string Name {  get; private set; }
    private void Awake()
    {
        MaxHp = data.MaxHp;
        AttackPower = data.AttackPower;
        MoveSpeed = data.MoveSpeed;
        Name = data.ThisName;

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
        Debug.Log("»ç¸Á");
    }
}