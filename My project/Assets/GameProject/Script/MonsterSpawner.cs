using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private MonsterManager monsterManager;

    [Header("플레이어 주변 소환 범위")]
    [SerializeField] private float minSpawnDistance = 15f;
    [SerializeField] private float maxSpawnDistance = 25f;

    [Header("NavMesh 위치 탐색 범위")]
    [SerializeField] private float navMeshSampleDistance = 5f;

    private void Awake()
    {
        if (player == null)
        {
            PlayerStatus playerStatus = FindAnyObjectByType<PlayerStatus>();

            if (playerStatus != null)
            {
                player = playerStatus.transform;
            }
        }

        if (monsterManager == null)
        {
            monsterManager = FindAnyObjectByType<MonsterManager>();
        }
    }

    public void Spawn(SpawnData spawnData)
    {
        if (spawnData == null)
            return;

        MonsterStatus[] monsterPrefabs = spawnData.MonsterPrefabs;

        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            Debug.LogWarning("SpawnData에 몬스터 프리팹이 없습니다.");
            return;
        }

        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            SpawnMonster(monsterPrefabs);
        }
    }

    private void SpawnMonster(MonsterStatus[] monsterPrefabs)
    {
        MonsterStatus selectedPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

        if (selectedPrefab == null)
        {
            Debug.LogWarning("몬스터 프리팹이 비어 있습니다.");
            return;
        }

        if (!TryGetSpawnPosition(out Vector3 spawnPosition))
        {
            Debug.LogWarning("NavMesh 위에서 소환 위치를 찾지 못했습니다.");
            return;
        }

        MonsterStatus spawnedMonster =
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        if (monsterManager == null)
        {
            Debug.LogError("MonsterManager가 연결되어 있지 않습니다.");
            Destroy(spawnedMonster.gameObject);
            return;
        }

        monsterManager.RegisterMonster(spawnedMonster);
    }

    private bool TryGetSpawnPosition(out Vector3 spawnPosition)
    {
        spawnPosition = Vector3.zero;

        if (player == null)
            return false;

        if (!NavMesh.SamplePosition(player.position, out NavMeshHit playerHit, 10f, NavMesh.AllAreas))
        {
            return false;
        }

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        Vector3 desiredPosition = playerHit.position + new Vector3(randomDirection.x, 0f, randomDirection.y) * randomDistance;

        if (!NavMesh.SamplePosition(desiredPosition, out NavMeshHit hit, navMeshSampleDistance, NavMesh.AllAreas))
        {
            return false;
        }

        spawnPosition = hit.position;
        return true;
    }
}