using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private MonsterStatus status;
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        FindPlayer();

    }
    private void OnEnable()
    {
        status.OnDead += StopMove;
    }

    private void OnDisable()
    {
        status.OnDead -= StopMove;
    }


    private void Start()
    {
        agent.speed = status.MoveSpeed;
    }

    private void StopMove()
    {
        if (agent == null || !agent.isActiveAndEnabled) return;

        agent.isStopped = true;
        agent.ResetPath();
    }
    void FindPlayer()
    {
        if (target != null) return;

        PlayerStatus playerStatus = FindAnyObjectByType<PlayerStatus>();

        if (playerStatus != null)
        {
            target = playerStatus.transform;
        }
    }

    private void Update()
    {
        if (status == null || status.IsDead) return;
        if (target == null) return;
        if (agent == null || !agent.isActiveAndEnabled) return;

        agent.SetDestination(target.position);
    }

}
