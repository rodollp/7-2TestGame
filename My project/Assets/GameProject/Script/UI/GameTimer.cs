using System;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private StageData stageData;

    private float playTime;
    private bool isStageTimeEnded;

    public float PlayTime => playTime;
    public bool IsStageTimeEnded => isStageTimeEnded;

    public event Action OnStageTimeEnded;

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

        if (isStageTimeEnded)
            return;

        playTime += Time.deltaTime;

        if (playTime >= stageData.StageDuration)
        {
            playTime = stageData.StageDuration;
            isStageTimeEnded = true;

            UpdateTimerUI();
            OnStageTimeEnded?.Invoke();
            return;
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
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

        return 0f;
    }

    public void ResetTimer()
    {
        playTime = 0f;
        isStageTimeEnded = false;

        UpdateTimerUI();
    }
}