using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private readonly HashSet<MonsterStatus> aliveMonsters = new();
    private readonly Dictionary<MonsterStatus, Action> deathCallbacks = new();

    public IReadOnlyCollection<MonsterStatus> AliveMonsters => aliveMonsters;
    public int AliveMonsterCount => aliveMonsters.Count;

    public event Action OnAllMonstersDead;

    public void RegisterMonster(MonsterStatus monster)
    {
        if (monster == null)
            return;

        // 같은 몬스터가 중복 등록되는 것을 방지
        if (!aliveMonsters.Add(monster))
            return;

        Action deathCallback = () => HandleMonsterDead(monster);

        deathCallbacks.Add(monster, deathCallback);
        monster.OnDead += deathCallback;
    }

    public void UnregisterMonster(MonsterStatus monster)
    {
        if (monster == null)
            return;

        if (!aliveMonsters.Remove(monster))
            return;

        if (deathCallbacks.TryGetValue(monster, out Action deathCallback))
        {
            monster.OnDead -= deathCallback;
            deathCallbacks.Remove(monster);
        }
    }

    private void HandleMonsterDead(MonsterStatus monster)
    {
        UnregisterMonster(monster);

        if (aliveMonsters.Count == 0)
        {
            OnAllMonstersDead?.Invoke();
        }
    }

    public void ResetManager()
    {
        foreach (MonsterStatus monster in aliveMonsters)
        {
            if (monster == null)
                continue;

            if (deathCallbacks.TryGetValue(monster, out Action deathCallback))
            {
                monster.OnDead -= deathCallback;
            }
        }

        aliveMonsters.Clear();
        deathCallbacks.Clear();
    }
}