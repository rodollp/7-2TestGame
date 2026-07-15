using UnityEngine;

public class MonsterDrop : MonoBehaviour
{
    [SerializeField] private MonsterStatus status;
    [SerializeField] private ExpOrb expOrbPrefab;
    [SerializeField] private GoldOrb goldOrbPrefab;
    [SerializeField] private PlayerWallet playerWallet;

    private void Awake()
    {
        if (status == null) status = GetComponent<MonsterStatus>();

        if (playerWallet == null) playerWallet = FindAnyObjectByType<PlayerWallet>();
    }

    private void OnEnable()
    {
        if (status != null) status.OnDead += DropReward;
    }

    private void OnDisable()
    {
        if (status != null) status.OnDead -= DropReward;
    }

    private void DropReward()
    {
        DropExpOrb();
        DropGoldOrb();
    }

    private void DropGoldOrb()
    {
        if (goldOrbPrefab == null) return;
        
        GoldOrb orb = Instantiate(goldOrbPrefab,transform.position,Quaternion.identity);
        orb.Init(status.Gold,playerWallet);

        
    }
    private void DropExpOrb()
    {
        if (expOrbPrefab == null) return;

        ExpOrb orb = Instantiate(expOrbPrefab,transform.position,Quaternion.identity);

        orb.Init(status.Exp);
    }

    
}