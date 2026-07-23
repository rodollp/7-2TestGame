using UnityEngine;

public class MonsterSpawnSystem : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private GameTimer gameTimer;

    private float spawnTimer;
    private int currentSpawnIndex;

    private void Start()
    {
        ResetSpawnSystem();
    }

    private void Update()
    {
        if (stageData == null || monsterSpawner == null || gameTimer == null)
        {
            return;
        }

        if (gameTimer.IsStageTimeEnded)
            return;

        SpawnData currentSpawnData = GetCurrentSpawnData();

        if (currentSpawnData == null)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer < currentSpawnData.SpawnInterval)
            return;

        monsterSpawner.Spawn(currentSpawnData);
        spawnTimer = 0f;
    }

    private SpawnData GetCurrentSpawnData()
    {
        SpawnData[] spawnDatas = stageData.SpawnDatas;

        if (spawnDatas == null || spawnDatas.Length == 0)
            return null;

        while (currentSpawnIndex < spawnDatas.Length)
        {
            SpawnData currentData = spawnDatas[currentSpawnIndex];

            if (currentData == null)
            {
                currentSpawnIndex++;
                spawnTimer = 0f;
                continue;
            }

            if (gameTimer.PlayTime < currentData.StartTime)
                return null;

            if (gameTimer.PlayTime < currentData.EndTime)
                return currentData;

            currentSpawnIndex++;
            spawnTimer = 0f;
        }

        return null;
    }

    public void ResetSpawnSystem()
    {
        spawnTimer = 0f;
        currentSpawnIndex = 0;
    }
}