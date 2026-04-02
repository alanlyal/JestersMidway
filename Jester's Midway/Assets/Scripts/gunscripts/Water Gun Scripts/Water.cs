using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{
    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
