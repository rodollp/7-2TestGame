using Assets.GameProject.Script;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private MonsterManager monsterManager;

    private void Awake()
    {
        if (monsterManager == null)
        {
            monsterManager = FindAnyObjectByType<MonsterManager>();
        }
    }

    public IDamageable FindNearestTarget(Vector3 origin,float range)
    {
        IDamageable target = null;
        float nearestDistance = float.MaxValue;

        foreach (MonsterStatus monster in monsterManager.AliveMonsters)
        {
            if (monster == null || monster.IsDead)
                continue;

            float distance =Vector3.Distance(origin,monster.transform.position);

            if (distance > range)
                continue;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                target = monster;
            }
        }

        return target;
    }

    public List<IDamageable> FindTargetsInRange(Vector3 origin,float range)
    {
        List<IDamageable> targets = new();

        foreach (MonsterStatus monster in monsterManager.AliveMonsters)
        {
            if (monster == null || monster.IsDead)
                continue;

            float distance =
                Vector3.Distance(origin,monster.transform.position);

            if (distance <= range)
            {
                targets.Add(monster);
            }
        }

        return targets;
    }
}