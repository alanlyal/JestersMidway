using UnityEngine;

public class SimpleNPC : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 2f;
    public float wanderRadius = 5f;
    public float waitTime = 2f;

    private Vector3 targetPosition;
    private float timer;
    private bool isWaiting;

    void Start()
    {
        // Set the first random spot relative to where they start
        SetNewRandomTarget();
    }

    void Update()
    {
        if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                isWaiting = false;
                timer = 0;
                SetNewRandomTarget();
            }
        }
        else
        {
            // Move toward the target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Rotate to look where they are going
            Vector3 lookDir = targetPosition - transform.position;
            if (lookDir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), 5f * Time.deltaTime);
            }

            // Check if they reached the spot
            if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
            {
                isWaiting = true;
            }
        }
    }

    void SetNewRandomTarget()
    {
        // Pick a random spot around the NPC's current position
        float randomX = Random.Range(-wanderRadius, wanderRadius);
        float randomZ = Random.Range(-wanderRadius, wanderRadius);

        targetPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
}