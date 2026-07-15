using UnityEngine;

public class GoldOrb : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float collectDistance = 0.5f;

    private PlayerWallet wallet;
    private int goldAmount;

    public void Init(int gold, PlayerWallet target)
    {
        goldAmount = gold;
        wallet = target;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (wallet == null) return;

        Vector3 targetPosition = wallet.transform.position;

        transform.position = Vector3.MoveTowards(transform.position,targetPosition,moveSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position,targetPosition);

        if (distance <= collectDistance)
        {
            wallet.AddGold(goldAmount);
            Destroy(gameObject);
        }
    }
}