using UnityEngine;

[System.Serializable]
public class SpawnData
{
    [SerializeField] private float startTime;
    [SerializeField] private float endTime;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int spawnCount;
    [SerializeField] private MonsterStatus[] monsterPrefabs;

    public float StartTime => startTime;
    public float EndTime => endTime;
    public float SpawnInterval => spawnInterval;
    public int SpawnCount => spawnCount;
    public MonsterStatus[] MonsterPrefabs => monsterPrefabs;

    
}