using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    [SerializeField] private MonsterStatus status;

    private PlayerStatus targetPlayer;
    private float attackTimer;
    private bool canAttack;

    private void Awake()
    {
        if (status == null)
        {
            status = GetComponentInParent<MonsterStatus>();
        }
    }

    private void OnEnable()
    {
        attackTimer = 0f;
        targetPlayer = null;
        canAttack = true;

        if (status != null)
        {
            status.OnDead += StopAttack;
        }
    }

    private void OnDisable()
    {
        if (status != null)
        {
            status.OnDead -= StopAttack;
        }
    }

    private void Update()
    {
        if (!canAttack)
        {
            return;
        }

        if (targetPlayer == null)
        {
            return;
        }

        if (status == null || status.IsDead)
        {
            return;
        }

        attackTimer += Time.deltaTime;

        if (attackTimer < status.AttackCoolDown)
        {
            return;
        }

        targetPlayer.TakeDamage(status.AttackPower);
        attackTimer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        targetPlayer = other.GetComponentInParent<PlayerStatus>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerStatus player =other.GetComponentInParent<PlayerStatus>();

        if (targetPlayer == player)
        {
            targetPlayer = null;
            attackTimer = 0f;
        }
    }

    private void StopAttack()
    {
        canAttack = false;
        targetPlayer = null;
        attackTimer = 0f;
    }
}