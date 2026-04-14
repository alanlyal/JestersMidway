using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Transform playerSpawn;

    [Header("NPC")]
    public GameObject enemyPrefab; // your "Enemy" prefab
    public Transform enemySpawn;
    private GameObject currentEnemy;

    [Header("Exit")]
    public Transform exitPoint;

    [Header("Events")]
    [SerializeField] private VoidEventChannel duelWinChannel;

    private bool gameStarted = false;
    private bool winTriggered = false;
    public void StartMatch()
    {
        if (gameStarted) return;
        gameStarted = true;
        winTriggered = false;
        Debug.Log("Match started");
        if (player != null && playerSpawn != null)
            player.transform.position = playerSpawn.position;
        if (enemyPrefab != null && enemySpawn != null)
        {
            currentEnemy = Instantiate(enemyPrefab, enemySpawn.position, Quaternion.identity);
            EnemyHealth enemyHealth = currentEnemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.OnDeath += OnEnemyDeath;
            }
        }
        else
        {
            Debug.LogWarning("Enemy prefab or spawn not assigned");
        }
    }
    private void OnEnemyDeath()
    {
        if (winTriggered) return;
        winTriggered = true;
        Debug.Log("Player wins");
        if (duelWinChannel != null)
            duelWinChannel.RaiseEvent();
        EndMatch();
    }
    public void EndMatch()
    {
        gameStarted = false;
        Debug.Log("Match ended");
        if (player != null && exitPoint != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                player.transform.position = exitPoint.position;
                cc.enabled = true;
            }
            else
            {
                player.transform.position = exitPoint.position;
            }
        }
        else
        {
            Debug.LogWarning("Player or ExitPoint not assigned");
        }
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
            currentEnemy = null;
        }
    }
    public bool IsGameRunning()
    {
        return gameStarted;
    }
}