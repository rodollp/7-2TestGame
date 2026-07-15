using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    public Vector3 SpawnPosition => spawnPoint.position;

    public Projectile Spawn(Projectile projectilePrefab,Vector3 direction)
    {
        return Instantiate(projectilePrefab,spawnPoint.position,Quaternion.LookRotation(direction));
    }
}