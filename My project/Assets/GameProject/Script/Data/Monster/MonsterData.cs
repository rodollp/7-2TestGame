using UnityEngine;

[CreateAssetMenu(menuName ="Data/Monster Data")]
public class MonsterData : CreatureData
{
    [SerializeField] private int exp;
    [SerializeField] private int gold;
    [SerializeField] private float coolDown;
    public int Exp => exp;
    public int Gold => gold;
    
    public float CoolDown => coolDown;

}
