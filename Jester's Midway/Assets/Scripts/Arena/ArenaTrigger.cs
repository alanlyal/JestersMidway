using UnityEngine;

public class ArenaTrigger : MonoBehaviour
{
    public GameObject promptText;

    private bool playerInZone = false;

    void Start()
    {
        if (promptText != null)
            promptText.SetActive(false);
    }

    [System.Obsolete]
    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");

            FindObjectOfType<GameManager>().StartMatch();

            if (promptText != null)
                promptText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;

            if (promptText != null)
                promptText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;

            if (promptText != null)
                promptText.SetActive(false);
        }
    }
}