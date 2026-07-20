using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private MonsterStatus status;
    [SerializeField] private Transform target;
    [SerializeField] private float pathUpdateInterval = 0.15f;

    private NavMeshAgent agent;
    private float pathTimer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        FindPlayer();
    }

    private void OnEnable()
    {
        if (status != null)
        {
            status.OnDead += StopMove;
        }

        pathTimer = 0f;
    }

    private void OnDisable()
    {
        if (status != null)
        {
            status.OnDead -= StopMove;
        }
    }

    private void Start()
    {
        if (agent != null && status != null)
        {
            agent.speed = status.MoveSpeed;
        }
    }

    private void Update()
    {
        if (status == null || status.IsDead)
        {
            return;
        }

        if (target == null)
        {
            FindPlayer();
            return;
        }

        if (agent == null || !agent.isActiveAndEnabled || !agent.isOnNavMesh)
        {
            return;
        }

        pathTimer += Time.deltaTime;

        if (pathTimer < pathUpdateInterval)
        {
            return;
        }

        pathTimer = 0f;
        agent.SetDestination(target.position);
    }

    private void StopMove()
    {
        if (agent == null || !agent.isActiveAndEnabled || !agent.isOnNavMesh)
        {
            return;
        }

        agent.isStopped = true;
        agent.ResetPath();
    }

    private void FindPlayer()
    {
        if (target != null)
        {
            return;
        }

        PlayerStatus playerStatus = FindAnyObjectByType<PlayerStatus>();

        if (playerStatus != null)
        {
            target = playerStatus.transform;
        }
    }
}