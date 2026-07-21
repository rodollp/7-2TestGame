using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject gameOverPanel;

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        ChangeState(GameState.Title);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Title:
                EnterTitle();
                break;

            case GameState.Playing:
                EnterPlaying();
                break;

            case GameState.LevelUp:
                EnterLevelUp();
                break;

            case GameState.GameOver:
                EnterGameOver();
                break;
        }
    }

    private void EnterTitle()
    {
        SetGamePaused(true);
        SetCursorState(true);
        SetPanels(showTitle: true,showGame: false,showLevelUp: false,showGameOver: false);
    }

    private void EnterPlaying()
    {
        SetGamePaused(false);
        SetCursorState(false);
        SetPanels(showTitle: false,showGame: true,showLevelUp: false,showGameOver: false);
    }

    private void EnterLevelUp()
    {
        SetGamePaused(true);
        SetCursorState(true);
        SetPanels(showTitle: false,showGame: true,showLevelUp: true,showGameOver: false);
    }

    private void EnterGameOver()
    {
        SetGamePaused(true);
        SetCursorState(true);
        SetPanels(showTitle: false,showGame: false,showLevelUp: false,showGameOver: true);
    }

    private void SetGamePaused(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void SetCursorState(bool isVisible)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void SetPanels(bool showTitle,bool showGame,bool showLevelUp,bool showGameOver)
    {
        titlePanel.SetActive(showTitle);
        gamePanel.SetActive(showGame);
        levelUpPanel.SetActive(showLevelUp);
        gameOverPanel.SetActive(showGameOver);
    }

    public void StartGame()
    {
        ChangeState(GameState.Playing);
    }

    public void OpenLevelUp()
    {
        ChangeState(GameState.LevelUp);
    }

    public void CloseLevelUp()
    {
        ChangeState(GameState.Playing);
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    public void ReturnToTitle()
    {
        ChangeState(GameState.Title);
    }
}