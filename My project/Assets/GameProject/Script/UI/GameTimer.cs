using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private StageData stageData;

    private float playTime;

    private void Awake()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (gameStateManager.CurrentState != GameState.Playing)
            return;

        if (stageData == null)
            return;

        playTime += Time.deltaTime;

        if (playTime >= stageData.StageDuration)
        {
            playTime = stageData.StageDuration;
        }

        float remainingWaveTime = GetRemainingWaveTime();

        gameUI.UpdatePlayTime(playTime);
        gameUI.UpdateNextEventTime(remainingWaveTime);
    }

    private float GetRemainingWaveTime()
    {
        SpawnData[] spawnDatas = stageData.SpawnDatas;

        if (spawnDatas == null || spawnDatas.Length == 0) 
            return 0f;

        foreach (SpawnData spawnData in spawnDatas)
        {
            bool isCurrentWave =
                playTime >= spawnData.StartTime &&
                playTime < spawnData.EndTime;

            if (isCurrentWave)
            {
                return spawnData.EndTime - playTime;
            }
        }

        // 현재 활성화된 웨이브가 없는 시간대
        return 0f;
    }

    public void ResetTimer()
    {
        playTime = 0f;

        gameUI.UpdatePlayTime(playTime);
        gameUI.UpdateNextEventTime(GetRemainingWaveTime());
    }
}