using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
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

        // 아직 추적 상태가 아닐 때만 수집 범위를 검사
        if (!isChasing)
        {
            if (distance > player.CollectionRange) return;

            // 한 번 범위 안에 들어오면 추적 시작
            isChasing = true;
        }

        // 추적 시작 후에는 범위를 벗어나도 계속 따라옴
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;

        if (distance <= collectDistance)
        {
            player.AddExp(expAmount);
            Destroy(gameObject);
        }
    }
}