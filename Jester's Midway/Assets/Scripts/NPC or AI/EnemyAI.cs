using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform player; // This should stay empty on the Prefab asset
    public Transform shootPoint; // This should be a child object of the Enemy Prefab

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float stopDistance = 6f;

    [Header("Shooting")]
    public float fireRate = 1f;
    public float damage = 10f;

    private float nextFireTime;

    void Awake()
    {
        
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("EnemyAI: Could not find an object with the 'Player' tag!");
            }
        }
    }

    void Update()
    {
        // If the player still isn't found, don't do anything
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Look at Player
        Vector3 lookDir = player.position - transform.position;
        lookDir.y = 0; 
        if (lookDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookDir);

        // Move to Player
        if (distance > stopDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }

        // Shoot Player
        if (distance <= stopDistance && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Ensure we have a shoot point to avoid errors
        if (shootPoint == null) return;

        Debug.Log("Enemy shooting at " + player.name);

        Ray ray = new Ray(shootPoint.position, shootPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Make sure the object we hit has the "Player" tag
            if (hit.collider.CompareTag("Player"))
            {
                
                PlayerHealth hp = hit.collider.GetComponent<PlayerHealth>();

                if (hp != null)
                {
                    hp.TakeDamage(damage);
                }
            }
        }
    }
}