using UnityEngine;

public class ArenaTrigger : MonoBehaviour
{
    private bool triggered = false;

    [System.Obsolete]
    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            Debug.Log("Player entered arena ? start game");

            FindObjectOfType<GameManager>().StartMatch();
        }
    }
}