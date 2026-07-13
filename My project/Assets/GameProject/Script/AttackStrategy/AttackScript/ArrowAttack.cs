using Assets.GameProject.Script;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Attack Strategy/Arrow Attack")]
public class ArrowAttack : AttackStrategy
{
    [SerializeField] private Projectile projectilePrefab;

    public override void Attack(
        AttackContext context,
        WeaponStatus weapon,
        IDamageable target)
    {
        MonoBehaviour targetObject = target as MonoBehaviour;

        if (targetObject == null)
            return;

        Vector3 origin =
            context.ProjectileSpawner.SpawnPosition;

        Vector3 direction =(targetObject.transform.position - origin).normalized;

        Projectile projectile =context.ProjectileSpawner.Spawn(projectilePrefab,direction);

        projectile.Init(direction,weapon.CurrentData.ProjectileSpeed,context.PlayerAttack,weapon);
    }
}