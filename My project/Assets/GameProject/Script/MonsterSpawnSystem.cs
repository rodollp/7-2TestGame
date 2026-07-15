using UnityEngine;

public class MonsterSpawnSystem : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private MonsterSpawner monsterSpawner;

    private float gameTimer;
    private float spawnTimer;

    private int currentSpawnIndex;

    private void Start()
    {
        gameTimer = 0f;
        spawnTimer = 0f;
        currentSpawnIndex = 0;
    }

    private void Update()
    {
        // 스테이지 데이터가 없거나 몬스터스포너가 없을경우에 실행취소
        if (stageData == null || monsterSpawner == null)
            return;
        // 게임 타이머가 총 플레이 시간보다 같거나 크면 실행이 안되게 막기
        if (gameTimer >= stageData.StageDuration)
            return;
        //플레이 시간 저장
        gameTimer += Time.deltaTime;
        // 
        SpawnData currentSpawnData = GetCurrentSpawnData();

        if (currentSpawnData == null)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer < currentSpawnData.SpawnInterval)
            return;

        monsterSpawner.Spawn(currentSpawnData);
        spawnTimer = 0f;
    }

    private SpawnData GetCurrentSpawnData()
    {
        SpawnData[] spawnDatas = stageData.SpawnDatas;
        //데이터가 없거나 한개도 안만들었으면 null
        if (spawnDatas == null || spawnDatas.Length == 0)
            return null;

        while (currentSpawnIndex < spawnDatas.Length)
        {
            SpawnData currentData = spawnDatas[currentSpawnIndex];

            if (gameTimer < currentData.StartTime)
                return null;

            if (gameTimer < currentData.EndTime)
                return currentData;

            currentSpawnIndex++;
            spawnTimer = 0f;
        }

        return null;
    }
}