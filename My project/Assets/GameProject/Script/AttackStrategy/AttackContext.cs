using UnityEngine;

public class AttackContext
{
    public PlayerAttack PlayerAttack { get; }
    public ProjectileSpawner ProjectileSpawner { get; }
    public TargetFinder TargetFinder { get; }
    public Transform AttackerTransform { get; }

    public AttackContext(PlayerAttack playerAttack,ProjectileSpawner projectileSpawner,TargetFinder targetFinder,Transform attackerTransform)
    {
        PlayerAttack = playerAttack;
        ProjectileSpawner = projectileSpawner;
        TargetFinder = targetFinder;
        AttackerTransform = attackerTransform;

    }
}