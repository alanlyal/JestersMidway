using Unity.VisualScripting;
using UnityEngine;

public class WaterTarget : MonoBehaviour
{
    public float points = 0f;
    public float pointsWinThreshold = 500f;
    public float moveTimer = 5f; // moves every n seconds.
    public GameObject winText;
    public float gameResetTimer = 10f; // amount of seconds until resetting the score

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

            if (points >= pointsWinThreshold)
            {
                ActivateWin();
            }
        }
    }

    void MoveTarget()
    {
        transform.position = WaterTargetBounds.Instance.getRandomPosition();
    }

    void ActivateWin()
    {
        winText.SetActive(true);

        Invoke(nameof(DeactivateWin), gameResetTimer);
    }

    void DeactivateWin()
    {
        winText.SetActive(false);
        points = 0f;
    }
}
