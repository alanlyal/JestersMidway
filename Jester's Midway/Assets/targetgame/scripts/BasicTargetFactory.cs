using UnityEngine;

public class BasicTargetFactory : TargetFactory
{
    [SerializeField] private int initialPoolSize = 1;

    protected override int GetInitialCount()
    {
        return initialPoolSize;
    }

    public override Target CreateTarget()
    {
        Vector3 spawnPos = TargetBounds.Instance.getRandomPosition();

        GameObject newTargetObj = Instantiate(targetPrefab, spawnPos, Quaternion.identity);

        float randomScale = Random.Range(0.5f, 1.5f);
        newTargetObj.transform.localScale = Vector3.one * randomScale;

        return newTargetObj.GetComponent<Target>();
    }
}