using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject gameOverPanel;


    private void Awake()
    {
        ShowTitle();
    }
    public void ShowTitle()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        titlePanel.SetActive(true);
        gamePanel.SetActive(false);
        levelUpPanel.SetActive(false);
        gameOverPanel.SetActive(false);

    }

    public void GameStart()
    {

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        titlePanel.SetActive(false);
        gamePanel.SetActive(true);
        

    }

}
