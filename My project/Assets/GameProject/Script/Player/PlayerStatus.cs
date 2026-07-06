using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private PlayerData data;

    public int CurrentHp { get; private set; }
    public int MaxHp { get; private set; }
    public int AttackPower { get; private set; }
    public float MoveSpeed { get; private set; }
    public float JumpPower { get; private set; }
    
    public bool IsDead { get; private set; }

    private void Awake()
    {
        MaxHp = data.MaxHp;
        AttackPower = data.AttackPower;
        MoveSpeed = data.MoveSpeed;
        JumpPower = data.JumpPower;
        CurrentHp = MaxHp;
    }


    public void TakeDamage(int damage)
    {
        if (IsDead)  return;
        
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            Die();
            
        }

    }

    void Die()
    {
        if (IsDead) return; 
        IsDead = true;
        CurrentHp = 0;
    }
}