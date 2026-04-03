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

    private bool gameStarted = false;

    public void StartMatch()
    {
        if (gameStarted) return;

        gameStarted = true;

        Debug.Log("MATCH STARTED");

        // Move player into arena
        if (player != null && playerSpawn != null)
            player.transform.position = playerSpawn.position;

        // Spawn enemy
        if (enemyPrefab != null && enemySpawn != null)
        {
            currentEnemy = Instantiate(enemyPrefab, enemySpawn.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Enemy prefab or spawn not assigned!");
        }
    }

    public void EndMatch()
    {
        gameStarted = false;

        // Destroy enemy
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