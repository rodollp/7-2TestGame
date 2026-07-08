using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Data")]
public class PlayerData : CreatureData
{
    //[SerializeField] private string thisName;
    //[SerializeField] private int maxHp = 100;
    //[SerializeField] private int attackPower = 10;
    //[SerializeField] private float moveSpeed = 5f;
    //public string ThisName => thisName;
    //public int MaxHp => maxHp;
    //public int AttackPower => attackPower;
    //public float MoveSpeed => moveSpeed;

    [SerializeField] private float jumpPower;
    [SerializeField] private int startLevel;
    [SerializeField] private int startNeedExp;
    [SerializeField] private float collectionRange;
    public float JumpPower => jumpPower;
    public int StartLevel => startLevel;
    public int NeedExp => startNeedExp;
    public float CollectionRange => collectionRange;



}
