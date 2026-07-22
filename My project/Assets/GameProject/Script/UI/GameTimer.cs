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

        float remainingTime = stageData.StageDuration - playTime;

        gameUI.UpdatePlayTime(playTime);
        gameUI.UpdateNextEventTime(remainingTime);
    }

    public void ResetTimer()
    {
        playTime = 0f;

        gameUI.UpdatePlayTime(playTime);

        if (stageData != null)
        {
            gameUI.UpdateNextEventTime(stageData.StageDuration);
        }
    }
}