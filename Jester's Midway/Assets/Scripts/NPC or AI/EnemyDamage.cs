using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 1f;

    private float nextAttackTime = 0f;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();

                if (hp != null)
                {
                    hp.TakeDamage(damage);
                }

                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}