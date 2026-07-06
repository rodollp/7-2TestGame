using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private WeaponData weaponData;

    private MonsterStatus target;
    private float timer;

    private void Awake()
    {
        if (playerAttack == null)
            playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        timer += Time.deltaTime;

        target = FindNearestMonster();

        if (CanAttack())
        {
            Debug.Log($"공격대상 : {target.Name}");
            playerAttack.Damage(target, weaponData);
            timer = 0f;
        }
    }

    private MonsterStatus FindNearestMonster()
    {
        MonsterStatus[] monsters = FindObjectsByType<MonsterStatus>(FindObjectsSortMode.None);

        MonsterStatus nearest = null;
        float nearestDistance = float.MaxValue;

        foreach (MonsterStatus monster in monsters)
        {
            if (monster == null) continue;
            if (monster.IsDead) continue;

            float distance = (monster.transform.position - transform.position).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = monster;
            }
        }

        return nearest;
    }

    private bool IsInRange()
    {
        if (target == null) return false;

        float distance =
            (target.transform.position - transform.position).sqrMagnitude;

        return distance <= weaponData.Range * weaponData.Range;
    }

    private bool CanAttack()
    {
        if (weaponData == null) return false;
        if (target == null) return false;
        if (target.IsDead) return false;
        if (timer < weaponData.Cooldown) return false;
        if (!IsInRange()) return false;

        return true;
    }
}