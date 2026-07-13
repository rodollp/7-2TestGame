public class AttackContext
{
    public PlayerAttack PlayerAttack { get; }
    public ProjectileSpawner ProjectileSpawner { get; }

    public AttackContext(
        PlayerAttack playerAttack,
        ProjectileSpawner projectileSpawner)
    {
        PlayerAttack = playerAttack;
        ProjectileSpawner = projectileSpawner;
    }
}