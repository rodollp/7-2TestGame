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
        playerStatus.OnExpChange += gameUI.UpdatePlayerExp;
        playerWallet.OnGoldChange += gameUI.UpdateGold;
    }

    private void OnDisable()
    {
        playerStatus.OnHpChange -= gameUI.UpdatePlayerHp;
        playerStatus.OnExpChange -= gameUI.UpdatePlayerExp;
        playerWallet.OnGoldChange -= gameUI.UpdateGold;
    }

    private void ShowToHUD()
    {
        gameUI.UpdatePlayerHp(playerStatus.CurrentHp,playerStatus.MaxHp);
        gameUI.UpdatePlayerExp(playerStatus.CurrentExp,playerStatus.NeedExp);
        gameUI.UpdateGold(playerWallet.Gold);
    }
}