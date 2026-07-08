
namespace Assets.GameProject.Script.Data.Weapon
{
    using UnityEngine;

    [System.Serializable]
    public class WeaponLevelData
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private float cooldown = 1f;
        [SerializeField] private float range = 5f;
        [SerializeField] private int projectileCount = 1;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private float areaSize = 1f;

        public int Damage => damage;
        public float Cooldown => cooldown;
        public float Range => range;
        public int ProjectileCount => projectileCount;
        public float ProjectileSpeed => projectileSpeed;
        public float AreaSize => areaSize;
    }
}
