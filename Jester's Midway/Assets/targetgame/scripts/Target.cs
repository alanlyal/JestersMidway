using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit()
    {
        if (TargetGameManager.Instance == null || TargetGameManager.Instance.IsGameOver())
            return;
        TargetGameManager.Instance.TargetHit();
        if (TargetBounds.Instance != null)
        {
            transform.position = TargetBounds.Instance.getRandomPosition();
        }
        else
        {
            Debug.LogError("TargetBounds is missing in the scene");
        }
    }
}