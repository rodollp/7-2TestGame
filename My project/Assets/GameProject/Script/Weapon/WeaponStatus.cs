using Assets.GameProject.Script.Data.Weapon;

public class WeaponStatus
{
    public WeaponData Data { get; private set; }
    public int CurrentLevel { get; private set; }

    public bool IsMaxLevel => CurrentLevel >= Data.MaxLevel;

    public string WeaponName => Data.WeaponName;
    public WeaponType WeaponType => Data.WeaponType;

    public WeaponLevelData CurrentData => Data.GetLevelData(CurrentLevel);

    public WeaponStatus(WeaponData data)
    {
        Data = data;
        CurrentLevel = 1;
    }

    public void LevelUp()
    {
        if (IsMaxLevel) return;

        CurrentLevel++;
    }
}