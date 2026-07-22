using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameStateManager gameStateManager;

    private void OnEnable()
    {
        playerStatus.OnDead += HandlePlayerDead;
    }

    private void OnDisable()
    {
        playerStatus.OnDead -= HandlePlayerDead;
    }

    private void HandlePlayerDead()
    {
        gameStateManager.GameOver();
    }
}