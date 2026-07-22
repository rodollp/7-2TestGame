using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    [Header("UI Panels")]
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameClearPanel;

    [Header("연출")]
    [SerializeField] private GameUI gameUI;
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
            case GameState.GameClear:
                EnterGameClear();
                break;

        }
    }

    private void EnterTitle()
    {
        SetGamePaused(true);
        SetCursorState(true);
        SetPanels(showTitle: true,showGame: false,showLevelUp: false,showGameOver: false, showGameClear: false);
    }

    private void EnterPlaying()
    {
        SetGamePaused(false);
        SetCursorState(false);
        SetPanels(showTitle: false,showGame: true,showLevelUp: false,showGameOver: false, showGameClear: false);
    }

    private void EnterLevelUp()
    {
        SetGamePaused(true);
        SetCursorState(true);
        SetPanels(showTitle: false,showGame: true,showLevelUp: true,showGameOver: false, showGameClear: false);
    }

    private void EnterGameOver()
    {
        SetGamePaused(true);
        SetCursorState(true);
        SetPanels(showTitle: false,showGame: false,showLevelUp: false,showGameOver: true,showGameClear: false);
    }

    private void EnterGameClear()
    {
        SetGamePaused(true);
        SetCursorState(true);

        SetPanels(showTitle: false,showGame: false,showLevelUp: false,showGameOver: false,showGameClear: true);
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

    private void SetPanels(bool showTitle,bool showGame,bool showLevelUp,bool showGameOver ,bool showGameClear)
    {
        titlePanel.SetActive(showTitle);
        gamePanel.SetActive(showGame);
        levelUpPanel.SetActive(showLevelUp);
        gameOverPanel.SetActive(showGameOver);
        gameClearPanel.SetActive(showGameClear);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying= false;
    #endif
    }
    public void StartGame()
    {
        ChangeState(GameState.Playing);
        gameUI.ShowStartMessage("5초 후 적들이 몰려옵니다", 3f);
        
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
        if(CurrentState == GameState.GameOver) return;
        ChangeState(GameState.GameOver);
    }

    public void GameClear()
    {
        if (CurrentState == GameState.GameClear || CurrentState == GameState.GameOver)
        {
            return;
        }

        ChangeState(GameState.GameClear);
    }

}