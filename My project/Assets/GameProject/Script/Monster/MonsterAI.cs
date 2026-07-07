using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
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
        agent.isStopped = true;
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
        if (agent == null) return;
        agent.SetDestination(target.position);
    }

}
