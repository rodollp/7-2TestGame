using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Data")]
public class PlayerData : CreatureData
{
    /// <creature>
    /// public string thisName;
    /// public int maxHp;
    /// public int attackPower;
    /// public float moveSpeed;
    /// </creature>
    /// 

    [SerializeField]private float jumpPower;

    public float JumpPower => jumpPower;

    
}
