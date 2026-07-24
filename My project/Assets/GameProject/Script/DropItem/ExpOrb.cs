using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float collectDistance = 0.5f;

    private PlayerStatus player;
    private int expAmount;
    private bool isChasing;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerStatus>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    public void Init(int exp)
    {
        expAmount = exp;
        isChasing = false;
    }

    private void MoveToPlayer()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position,player.transform.position);

        if (!isChasing)
        {
            if (distance > player.CollectionRange)
                return;

            isChasing = true;
        }

        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,moveSpeed * Time.deltaTime);

        float distanceAfterMove = Vector3.Distance(transform.position , player.transform.position);

        if (distanceAfterMove <= collectDistance)
        {
            Collect();
        }
    }

    private void Collect()
    {
        player.AddExp(expAmount);
        Destroy(gameObject);
    }
}