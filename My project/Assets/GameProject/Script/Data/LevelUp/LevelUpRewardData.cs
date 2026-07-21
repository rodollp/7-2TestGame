using UnityEngine;
public enum LevelUpRewardType
{
    PlayerStat,
    Weapon
}

public enum PlayerStatType
{
    MaxHp,
    AttackPower,
    MoveSpeed,
    JumpPower,
    CollectionRange
}


[CreateAssetMenu(menuName = "Data/Level Up Reward")]
public class LevelUpRewardData : ScriptableObject
{
    [Header("UI")]
    [SerializeField] private string rewardName;

    [TextArea]
    [SerializeField] private string description;

    [SerializeField] private Sprite icon;

    [Header("Reward Type")]
    [SerializeField] private LevelUpRewardType rewardType;

    [Header("Player Stat")]
    [SerializeField] private PlayerStatType statType;
    [SerializeField] private float value;

    [Header("Weapon")]
    [SerializeField] private WeaponData weaponData;

    public string RewardName => rewardName;
    public string Description => description;
    public Sprite Icon => icon;

    public LevelUpRewardType RewardType => rewardType;
    public PlayerStatType StatType => statType;
    public float Value => value;
    public WeaponData WeaponData => weaponData;
}
