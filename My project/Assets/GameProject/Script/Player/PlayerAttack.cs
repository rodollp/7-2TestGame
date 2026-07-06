using Assets.GameProject.Script;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;

    private void Awake()
    {
        if(status == null)
        {
            status = GetComponent<PlayerStatus>();
        }
    }
    public void Damage(IDamageable target,WeaponData weponData)
    {
        if(target == null)return;
        

        int finalDamage=status.AttackPower+ weponData.Damage;
        
        target.TakeDamage(finalDamage);
    }

}
