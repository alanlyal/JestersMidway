using UnityEngine;

public abstract class TargetFactory : MonoBehaviour
{
    [SerializeField] protected GameObject targetPrefab;

    void Start()
    {
        for (int i = 0; i < GetInitialCount(); i++)
        {
            CreateTarget();
        }
    }
    public abstract Target CreateTarget();
    protected virtual int GetInitialCount()
    {
        return 3;
    }
}