

using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float wanderRadius = 10f;
    public float waitTime = 2f;

    private Vector3 targetPosition;
    private float waitCounter;
    private bool isWaiting;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        if (isWaiting)
        {
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                isWaiting = false;
                PickNewTarget();
            }
            return;
        }

        // Move toward target
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Look at target
        transform.LookAt(targetPosition);

        // Reached target
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            isWaiting = true;
            waitCounter = waitTime;
        }
    }

    void PickNewTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection.y = 0f;

        targetPosition = transform.position + randomDirection;
    }
}