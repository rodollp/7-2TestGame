using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text playTime;
    [SerializeField] private TMP_Text eventTime;
    [SerializeField] private TMP_Text playerGold;
    [SerializeField] private TMP_Text playerHp;

    public void UpdatePlayTime(float time)
    {
        int minute = Mathf.FloorToInt(time / 60f);
        int second = Mathf.FloorToInt(time % 60f);

        playTime.text = $"Time:{minute:00}:{second:00}";
    }

    public void UpdateNextEventTime(float time)
    {
        time = Mathf.Max(time, 0f);

        int minute = Mathf.FloorToInt(time / 60f);
        int second = Mathf.CeilToInt(time % 60f);

        eventTime.text = $"Next {minute:00}:{second:00}";
    }

    public void UpdateGold(int gold)
    {
        playerGold.text = $"Gold : {gold}";
    }

    public void UpdatePlayerHp(int currentHp ,int maxHp)
    {
        playerHp.text = $"HP : {currentHp} / {maxHp}";
    }
}
