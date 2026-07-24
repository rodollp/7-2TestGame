using Assets.GameProject.Script;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Attack Strategy/Arrow Attack")]
public class ArrowAttack : AttackStrategy
{
    [SerializeField] private Projectile projectilePrefab;

    public override bool Attack(AttackContext context,WeaponStatus weapon)
    {
        IDamageable target = context.TargetFinder.FindNearestTarget(context.AttackerTransform.position,weapon.CurrentData.Range);

        MonoBehaviour targetObject =target as MonoBehaviour;

        if (targetObject == null)
            return false;

        Vector3 origin = context.ProjectileSpawner.SpawnPosition;

        Vector3 direction =(targetObject.transform.position - origin).normalized;

        Projectile projectile = context.ProjectileSpawner.Spawn(projectilePrefab,direction);

        if (projectile == null)
            return false;

        projectile.Init(direction,weapon.CurrentData.ProjectileSpeed,context.PlayerAttack,weapon);

        return true;
    }
}