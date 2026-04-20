using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset;
    void LateUpdate()
    {
        transform.position = cameraTransform.position + cameraTransform.TransformDirection(offset);
        transform.rotation = cameraTransform.rotation;
    }
}