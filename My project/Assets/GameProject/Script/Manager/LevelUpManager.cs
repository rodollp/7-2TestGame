using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private List<LevelUpRewardData> rewardPool;

    [Header("References")]
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private LevelUpRewardButton[] rewardButtons;
    [SerializeField] private WeaponInventory weaponInventory;

    private readonly List<LevelUpRewardData> selectedRewards = new();

    private int pendingLevelUpCount;
    private bool isSelectingReward;

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
        pendingLevelUpCount++;

        if (isSelectingReward)
        {
            return;
        }

        isSelectingReward = true;

        if (!ShowNextLevelUp())
        {
            FinishLevelUpSelection();
        }
    }

    private bool ShowNextLevelUp()
    {
        SelectRandomRewards(rewardButtons.Length);

        if (selectedRewards.Count == 0)
        {
            return false;
        }

        gameStateManager.OpenLevelUp();
        ShowRewards();

        return true;
    }

    private void SelectRandomRewards(int count)
    {
        selectedRewards.Clear();

        if (rewardPool == null || rewardPool.Count == 0)
        {
            return;
        }

        List<LevelUpRewardData> candidates = new();

        foreach (LevelUpRewardData reward in rewardPool)
        {
            if (CanSelectReward(reward))
            {
                candidates.Add(reward);
            }
        }

        if (candidates.Count == 0)
        {
            return;
        }

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
                rewardButtons[i].Init(selectedRewards[i],this);
            }
        }
    }

    public void SelectReward(LevelUpRewardData reward)
    {
        if (reward == null)
        {
            return;
        }

        if (!ApplyReward(reward))
        {
            return;
        }

        pendingLevelUpCount--;

        if (pendingLevelUpCount > 0 && ShowNextLevelUp())
        {
            return;
        }

        FinishLevelUpSelection();
    }

    private void FinishLevelUpSelection()
    {
        pendingLevelUpCount = 0;
        isSelectingReward = false;

        gameStateManager.CloseLevelUp();
    }

    private bool ApplyReward(LevelUpRewardData reward)
    {
        switch (reward.RewardType)
        {
            case LevelUpRewardType.PlayerStat:
                playerStatus.ApplyStatUpgrade(reward.StatType,reward.Value);

                return true;

            case LevelUpRewardType.Weapon:
                return weaponInventory.AddWeapon(reward.WeaponData);
        }

        return false;
    }

    private bool CanSelectReward(LevelUpRewardData reward)
    {
        if (reward == null)
        {
            return false;
        }

        switch (reward.RewardType)
        {
            case LevelUpRewardType.PlayerStat:
                return true;

            case LevelUpRewardType.Weapon:
                return weaponInventory.CanAddWeapon(reward.WeaponData);
        }

        return false;
    }
}