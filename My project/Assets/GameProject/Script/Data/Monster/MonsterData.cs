using UnityEngine;

[CreateAssetMenu(menuName ="Data/Monster Data")]
public class MonsterData : CreatureData
{
    [SerializeField] private int exp;
    [SerializeField] private int gold;

    public int Exp => exp;
    public int Gold => gold;
    

}
