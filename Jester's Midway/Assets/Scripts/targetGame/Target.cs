using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Hit()
    { 
        transform.position=TargetBounds.Instance.getRandomPosition();
    }
}
