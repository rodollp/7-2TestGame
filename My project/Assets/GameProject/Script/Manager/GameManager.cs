using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("게임 시스템")]
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private MonsterManager monsterManager;

    [Header("플레이어")]
    [SerializeField] private PlayerStatus playerStatus;

    private bool isGameFinished;

    private void OnEnable()
    {
        if (playerStatus != null)
            playerStatus.OnDead += HandlePlayerDead;

        if (gameTimer != null)
            gameTimer.OnStageTimeEnded += HandleStageTimeEnded;

        if (monsterManager != null)
            monsterManager.OnAllMonstersDead += HandleAllMonstersDead;
    }

    private void OnDisable()
    {
        if (playerStatus != null)
            playerStatus.OnDead -= HandlePlayerDead;

        if (gameTimer != null)
            gameTimer.OnStageTimeEnded -= HandleStageTimeEnded;

        if (monsterManager != null)
            monsterManager.OnAllMonstersDead -= HandleAllMonstersDead;
    }

    private void HandlePlayerDead()
    {
        if (isGameFinished)
            return;

        isGameFinished = true;
        gameStateManager.GameOver();
    }

    private void HandleStageTimeEnded()
    {
        TryGameClear();
    }

    private void HandleAllMonstersDead()
    {
        TryGameClear();
    }

    private void TryGameClear()
    {
        if (isGameFinished)
            return;

        if (!gameTimer.IsStageTimeEnded)
            return;

        if (monsterManager.AliveMonsterCount > 0)
            return;

        isGameFinished = true;
        gameStateManager.GameClear();
    }

    public void ResetGame()
    {
        isGameFinished = false;
    }
}