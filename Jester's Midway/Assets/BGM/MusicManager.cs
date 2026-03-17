using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("GameMusic");

        if(musicObjects.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

    }
}
