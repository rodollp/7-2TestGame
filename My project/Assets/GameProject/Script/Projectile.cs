using Assets.GameProject.Script;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;

    private Vector3 direction;
    private float speed;
    private float timer;

    private PlayerAttack owner;
    private WeaponStatus weapon;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null )
        {
            Debug.LogError("없습니다");
            enabled = false;
        }
    }

    public void Init(
        Vector3 moveDirection,
        float moveSpeed,
        PlayerAttack attack,
        WeaponStatus weaponStatus)
    {
        direction = moveDirection.normalized;
        speed = moveSpeed;
        owner = attack;
        weapon = weaponStatus;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            DisableProjectile();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(
            rb.position +
            direction * speed * Time.fixedDeltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (owner == null)
            return;

        if (other.transform.root == owner.transform.root)
            return;

        IDamageable target =
            other.GetComponentInParent<IDamageable>();

        if (target == null)
            return;

        owner.Damage(weapon, target);

        DisableProjectile();
    }

    private void DisableProjectile()
    {
        Destroy(gameObject);
    }
}