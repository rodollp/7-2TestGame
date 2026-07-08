using Assets.GameProject.Script;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;

    private WeaponStatus weaponStatus;
    private float timer;

    public void Init(WeaponStatus status)
    {
        weaponStatus = status;
    }

    private void Update()
    {
        if (weaponStatus == null) return;

        timer += Time.deltaTime;

        IDamageable target = FindNearestTarget();

        if (target == null) return;
        if (!IsInRange(target)) return;
        if (timer < weaponStatus.CurrentData.Cooldown) return;

        playerAttack.Damage(target, weaponStatus);
        timer = 0f;
    }

    private bool IsInRange(IDamageable target)
    {
        MonoBehaviour targetObj = target as MonoBehaviour;
        if (targetObj == null) return false;

        float distance = Vector3.Distance(transform.position, targetObj.transform.position);
        return distance <= weaponStatus.CurrentData.Range;
    }

    private IDamageable FindNearestTarget()
    {
        MonsterStatus[] monsters = FindObjectsByType<MonsterStatus>(FindObjectsSortMode.None);

        IDamageable nearestTarget = null;
        float nearestDistance = Mathf.Infinity;

        foreach (MonsterStatus monster in monsters)
        {
            if (monster.IsDead) continue;

            float distance = Vector3.Distance(transform.position, monster.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = monster;
            }
        }

        return nearestTarget;
    }
}