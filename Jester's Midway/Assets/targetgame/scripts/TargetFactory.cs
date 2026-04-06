using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab; 
    [SerializeField] private int initialPoolSize = 5;
    void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateTarget();
        }
    }
    public Target CreateTarget()
    {
        Vector3 spawnPos = TargetBounds.Instance.getRandomPosition();
        GameObject newTargetObj = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        Target targetScript = newTargetObj.GetComponent<Target>();
        float randomScale = Random.Range(0.5f, 1.5f);
        newTargetObj.transform.localScale = Vector3.one * randomScale;
        return targetScript;
    }
}