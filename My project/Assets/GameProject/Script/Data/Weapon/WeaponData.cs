using Assets.GameProject.Script.Data.Weapon;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Area,
    Projectile
}

[CreateAssetMenu(menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private WeaponLevelData[] levels;

    public string WeaponName => weaponName;
    public WeaponType WeaponType => weaponType;
    public int MaxLevel => levels.Length;

    public WeaponLevelData GetLevelData(int level)
    {
        int index = Mathf.Clamp(level - 1, 0, levels.Length - 1);
        return levels[index];
    }
}