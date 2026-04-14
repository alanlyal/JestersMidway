using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    [SerializeField] private GameDataEventChannel gameCompleteChannel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has decided to end game");
            if (gameCompleteChannel != null)
            {
                GameData data = new GameData();
                data.fileName = "Game Complete";

                gameCompleteChannel.RaiseEvent(data);
            }
            SceneManager.LoadScene("game over");
        }
    }
}
