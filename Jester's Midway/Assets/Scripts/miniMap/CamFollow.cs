using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerPosition;
    public float height = 50f;
    public float followSpeed = 5f;
    private void LateUpdate()
    {
        if (playerPosition != null)
        {
            Vector3 targetPosition = new Vector3(playerPosition.position.x,height,playerPosition.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}