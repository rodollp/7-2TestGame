using UnityEngine;

public class GoldOrb : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float collectDistance = 0.5f;

    private PlayerWallet wallet;
    private int goldAmount;

    public void Init(int gold)
    {
        goldAmount = gold;
    }

    private void Awake()
    {
        wallet = FindAnyObjectByType<PlayerWallet>();
    }

    private void Update()
    {
        if (wallet == null) return;

        Vector3 dir = wallet.transform.position - transform.position;
        float distance = dir.magnitude;

        transform.position += dir.normalized * moveSpeed * Time.deltaTime;

        if (distance <= collectDistance)
        {
            wallet.AddGold(goldAmount);
            Destroy(gameObject);
        }
    }
}