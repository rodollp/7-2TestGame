
namespace Assets.GameProject.Script.Data.Weapon
{
    
    using UnityEngine;
    
    [System.Serializable]
    public struct WeaponLevelData
    {
        [Header("레벨별 무기 스펙")]
        [SerializeField] private int damage;
        [SerializeField] private float cooldown;
        [SerializeField] private float range;
        [SerializeField] private int projectileCount;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float areaSize;

        public int Damage => damage;
        public float Cooldown => cooldown;
        public float Range => range;
        public int ProjectileCount => projectileCount;
        public float ProjectileSpeed => projectileSpeed;
        public float AreaSize => areaSize;
    }
}
