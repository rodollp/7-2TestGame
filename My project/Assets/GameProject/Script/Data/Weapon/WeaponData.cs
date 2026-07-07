using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private int damage;
    [SerializeField] private float cooldown;
    [SerializeField] private float range;
    [SerializeField] private float radius;

    public string WeaponName => weaponName;
    public int Damage => damage;
    public float Cooldown => cooldown;
    public float Range => range;

    public float Radius => radius;

    private void OnValidate()
    {
        damage = Mathf.Max(0, damage);
        cooldown = Mathf.Max(0.1f, cooldown);
        range = Mathf.Max(0f, range);
        radius = Mathf.Max(0f, radius);
    }
}
