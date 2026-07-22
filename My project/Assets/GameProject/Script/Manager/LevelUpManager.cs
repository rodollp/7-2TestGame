using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private List<LevelUpRewardData> rewardPool;

    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private LevelUpRewardButton[] rewardButtons;
    [SerializeField] private WeaponInventory weaponInventory;

    private readonly List<LevelUpRewardData> selectedRewards = new();

    private void OnEnable()
    {
        if (playerStatus != null)
        {
            playerStatus.OnLevelUp += OpenLevelUp;
        }
    }

    private void OnDisable()
    {
        if (playerStatus != null)
        {
            playerStatus.OnLevelUp -= OpenLevelUp;
        }
    }

    private void OpenLevelUp()
    {
        gameStateManager.OpenLevelUp();

        SelectRandomRewards(rewardButtons.Length);
        ShowRewards();
    }

    private void SelectRandomRewards(int count)
    {
        selectedRewards.Clear();

        if (rewardPool == null || rewardPool.Count == 0)
        {
            Debug.LogWarning("������ ���� Ǯ�� ��� �ֽ��ϴ�.");
            return;
        }

        List<LevelUpRewardData> candidates = new(rewardPool);

        int selectCount = Mathf.Min(count, candidates.Count);

        for (int i = 0; i < selectCount; i++)
        {
            int randomIndex = Random.Range(0, candidates.Count);

            selectedRewards.Add(candidates[randomIndex]);
            candidates.RemoveAt(randomIndex);
        }
    }
    private void ShowRewards()
    {
        for (int i = 0; i < rewardButtons.Length; i++)
        {
            bool hasReward = i < selectedRewards.Count;

            rewardButtons[i].gameObject.SetActive(hasReward);

            if (hasReward)
            {
                rewardButtons[i].Init(
                    selectedRewards[i],
                    this);
            }
        }
    }
    public void SelectReward(LevelUpRewardData reward)
    {
        if (reward == null)
            return;

        bool isApplied = ApplyReward(reward);

        if (!isApplied)
        {
            return;
        }

        gameStateManager.CloseLevelUp();
    }

    private bool ApplyReward(LevelUpRewardData reward)
    {
        switch (reward.RewardType)
        {
            case LevelUpRewardType.PlayerStat:
                playerStatus.ApplyStatUpgrade(
                    reward.StatType,
                    reward.Value
                );

                return true;

            case LevelUpRewardType.Weapon:
                return weaponInventory.AddWeapon(
                    reward.WeaponData
                );
        }

        return false;
    }
}