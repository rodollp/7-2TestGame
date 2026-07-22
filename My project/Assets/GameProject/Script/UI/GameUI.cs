using System.Collections;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text playTime;
    [SerializeField] private TMP_Text eventTime;
    [SerializeField] private TMP_Text playerGold;
    [SerializeField] private TMP_Text playerHp;

    [Header("Message")]
    [SerializeField] private TMP_Text startText;
    [SerializeField] private TMP_Text eventText;

    private Coroutine startCoroutine;
    private Coroutine eventCoroutine;

    private void Awake()
    {
        startText.gameObject.SetActive(false);
        eventText.gameObject.SetActive(false);
    }

    public void ShowStartMessage(string message, float duration)
    {
        if (startCoroutine != null)
        {
            StopCoroutine(startCoroutine);
        }

        startCoroutine = StartCoroutine(ShowMessageRoutine(startText, message, duration, true));
    }

    public void ShowEventMessage(string message, float duration)
    {
        if (eventCoroutine != null)
        {
            StopCoroutine(eventCoroutine);
        }

        eventCoroutine = StartCoroutine(ShowMessageRoutine(eventText, message, duration, false));
    }

    private IEnumerator ShowMessageRoutine(TMP_Text text,string message,float duration,bool isStart)
    {
        text.text = message;
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        text.gameObject.SetActive(false);

        if (isStart)startCoroutine = null;
        else eventCoroutine = null;
    }

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

    public void UpdatePlayerHp(int currentHp, int maxHp)
    {
        playerHp.text = $"HP : {currentHp} / {maxHp}";
    }
}