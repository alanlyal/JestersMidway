using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private VoidEventChannel duelWinChannel;
    [SerializeField] private VoidEventChannel playerDeathChannel;
    [SerializeField] private VoidEventChannel targetCompleteChannel;
    [SerializeField] private GameDataEventChannel gameCompleteChannel;
    private bool duelUnlocked;
    private bool deathUnlocked;
    private bool targetUnlocked;
    private bool gameUnlocked;
    private void OnEnable()
    {
        if (duelWinChannel != null)
            duelWinChannel.OnEventRaised += OnDuelWin;
        if (playerDeathChannel != null)
            playerDeathChannel.OnEventRaised += OnPlayerDeath;
        if (targetCompleteChannel != null)
            targetCompleteChannel.OnEventRaised += OnTargetComplete;
        if (gameCompleteChannel != null)
            gameCompleteChannel.OnEventRaised += OnGameComplete;
    }

    private void OnDisable()
    {
        if (duelWinChannel != null)
            duelWinChannel.OnEventRaised -= OnDuelWin;
        if (playerDeathChannel != null)
            playerDeathChannel.OnEventRaised -= OnPlayerDeath;
        if (targetCompleteChannel != null)
            targetCompleteChannel.OnEventRaised -= OnTargetComplete;
        if (gameCompleteChannel != null)
            gameCompleteChannel.OnEventRaised -= OnGameComplete;
    }
    private void OnDuelWin()
    {
        if (duelUnlocked) return;
        duelUnlocked = true;
        Unlock("Warden");
    }
    private void OnPlayerDeath()
    {
        if (deathUnlocked) return;
        deathUnlocked = true;
        Unlock("how did this happen");
    }
    private void OnTargetComplete()
    {
        if (targetUnlocked) return;
        targetUnlocked = true;
        Unlock("Sharpshooter");
    }
    private void OnGameComplete(GameData data)
    {
        if (gameUnlocked) return;
        gameUnlocked = true;
        Unlock(" Game Complete Thanks for playing out game");
    }

    private void Unlock(string achievementName)
    {
        Debug.Log("Achievement: " + achievementName);
    }
}