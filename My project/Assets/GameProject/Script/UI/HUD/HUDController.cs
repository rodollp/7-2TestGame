using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private PlayerWallet playerWallet;
    [SerializeField] private GameUI gameUI;

    private void Start()
    {
        ShowToHUD();
    }

    private void OnEnable()
    {
        playerStatus.OnHpChange += gameUI.UpdatePlayerHp;
        playerWallet.OnGoldChange += gameUI.UpdateGold;
    }

    private void OnDisable()
    {
        playerStatus.OnHpChange -= gameUI.UpdatePlayerHp;
        playerWallet.OnGoldChange -= gameUI.UpdateGold;
    }

    private void ShowToHUD()
    {
        gameUI.UpdatePlayerHp(playerStatus.CurrentHp,playerStatus.MaxHp);

        gameUI.UpdateGold(playerWallet.Gold);
    }
}