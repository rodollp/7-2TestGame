using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameUI gameUI;

    [Header("Timer")]
    [SerializeField] private float eventInterval = 60f;

    private float playTime;
    private float nextEventTime;

    private void Awake()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (gameStateManager.CurrentState != GameState.Playing)
            return;

        playTime += Time.deltaTime;
        nextEventTime -= Time.deltaTime;

        if (nextEventTime <= 0f)
        {
            nextEventTime = eventInterval;
            OnEvent();
        }

        gameUI.UpdatePlayTime(playTime);
        gameUI.UpdateNextEventTime(nextEventTime);
    }

    private void OnEvent()
    {
        Debug.Log("다음 이벤트 발생!");
    }

    public void ResetTimer()
    {
        playTime = 0f;
        nextEventTime = eventInterval;

        gameUI.UpdatePlayTime(playTime);
        gameUI.UpdateNextEventTime(nextEventTime);
    }
}