using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Data")]
public class PlayerData : CreatureData
{
    [SerializeField]private float jumpPower;

    public float JumpPower => jumpPower;

    
}
