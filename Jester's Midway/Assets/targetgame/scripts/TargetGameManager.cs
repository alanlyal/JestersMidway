using UnityEngine;

public class TargetGameManager : MonoBehaviour
{
    public static TargetGameManager Instance;

    [SerializeField] float timeLeft = 20f;
    [SerializeField] int targetsToWin = 5;

    int targetsHit = 0;
    bool gameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void TargetHit()
    {
        if (gameOver) return;

        targetsHit++;

        if (targetsHit >= targetsToWin)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        Debug.Log("GAME OVER");
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}