using Assets.GameProject.Script;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]PlayerStatus status;

    private void Awake()
    {
        if(status == null)
        {
            status = GetComponent<PlayerStatus>();
        }
    }
    public void Damage(IDamageable target, WeaponStatus weaponStatus)
    {
        if (target == null) return;
        if (weaponStatus == null) return;

        int damage = weaponStatus.CurrentData.Damage + status.AttackPower;
        target.TakeDamage(damage);
    }
}