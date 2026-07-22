using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpRewardButton : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Button button;

    private LevelUpRewardData rewardData;
    private LevelUpManager levelUpManager;

    public void Init(
        LevelUpRewardData reward,
        LevelUpManager manager)
    {
        rewardData = reward;
        levelUpManager = manager;

        titleText.text = reward.RewardName;
        descriptionText.text = reward.Description;

        if (reward.Icon != null)
        {
            iconImage.sprite = reward.Icon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.enabled = false;
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(SelectReward);
    }

    private void SelectReward()
    {
        if (rewardData == null || levelUpManager == null)
            return;

        levelUpManager.SelectReward(rewardData);
    }
}