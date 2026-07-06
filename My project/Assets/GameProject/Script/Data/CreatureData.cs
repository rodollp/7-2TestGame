using UnityEngine;

public class CreatureData : ScriptableObject
{
    [SerializeField] private string thisName;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private float moveSpeed = 5f;

    public string ThisName => thisName;
    public int MaxHp => maxHp;
    public int AttackPower => attackPower;
    public float MoveSpeed => moveSpeed;

    protected virtual void OnValidate()
    {
        maxHp = Mathf.Max(1, maxHp);
        attackPower = Mathf.Max(0, attackPower);
        moveSpeed = Mathf.Max(0f, moveSpeed);
    }
}