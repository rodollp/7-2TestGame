using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    [SerializeField] private MonsterStatus status;
    private float attackTimer;

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        attackTimer += Time.deltaTime;

        if (attackTimer >= status.AttackCoolDown)
        {
            attackTimer = 0f;

            PlayerStatus player = collision.gameObject.GetComponent<PlayerStatus>();
            if (player != null)
            {
                player.TakeDamage(status.AttackPower);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attackTimer = 0f;
        }
    }
}
