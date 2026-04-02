using Unity.VisualScripting;
using UnityEngine;

public class WaterTarget : MonoBehaviour
{
    public float points = 0f;
    public float moveTimer = 5f; // moves every n seconds.

    void Start()
    {
        InvokeRepeating(nameof(MoveTarget), 0f, moveTimer);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Water(Clone)")
        {
            points++;
            Destroy(other.gameObject);
        }
    }

    void MoveTarget()
    {
        transform.position = WaterTargetBounds.Instance.getRandomPosition();
    }
}
