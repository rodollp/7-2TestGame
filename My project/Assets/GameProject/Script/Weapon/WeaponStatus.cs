using Assets.GameProject.Script.Data.Weapon;

/// <summary>
/// 플레이어가 보유한 무기의 상태를 관리한다.
/// 변하지 않는 정보는 WeaponData를 참조하고,
/// 플레이 중 변경되는 레벨 등의 상태만 관리한다.
/// </summary>
public class WeaponStatus
{
    public WeaponData Data { get; private set; }
   
    public int CurrentLevel { get; private set; }

    public bool IsMaxLevel => CurrentLevel >= Data.MaxLevel;

    public string WeaponName => Data.WeaponName;
    /// <summary>
    /// 근접,원거리,범위를 나타내는 WeaponType
    /// </summary>
    public WeaponType WeaponType => Data.WeaponType;

    /// <summary>
    /// 무기의 공격 타입을 반환한다.
    /// </summary>
    public WeaponLevelData CurrentData => Data.GetLevelData(CurrentLevel);

    /// <summary>
    /// WeaponData를 기반으로 새로운 무기 상태를 생성한다.
    /// 초기 레벨은 1이다.
    /// </summary>
    /// <param name="data">
    /// 무기의 원본 데이터.
    /// </param>
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