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
    }

    private void MoveToPlayer()
    {
        if (player == null) return;

        Vector3 dir = player.transform.position - transform.position;
        float distance = dir.magnitude;

        
        if (!isChasing)
        {
            if (distance > player.CollectionRange) return;

        
            isChasing = true;
        }

        
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;

        if (distance <= collectDistance)
        {
            player.AddExp(expAmount);
            Destroy(gameObject);
        }
    }
}