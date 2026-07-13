using Assets.GameProject.Script;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{

    public IDamageable FindNearestTarget(Vector3 orgin, float range)
    {
        MonsterStatus[] monsters = FindObjectsByType<MonsterStatus>(FindObjectsSortMode.None);

        IDamageable target = null;
        float nearestDistance = float.MaxValue;

        foreach (MonsterStatus monster in monsters)
        {
            if (monster.IsDead)
            {
                continue;
            }
            
            float distance = Vector3.Distance(orgin,monster.transform.position);
            if (distance > range)
            {
                continue;
            }

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                target = monster;
            }

        }

        return target;
    }

}
