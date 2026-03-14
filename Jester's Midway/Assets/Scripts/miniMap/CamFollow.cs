using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset = new Vector3(0f,10f,0f);
    public float followSpeed = 5f;
    private void LateUpdate()
    {
        if (playerPosition != null)
        {
            Vector3 targetPosition = playerPosition.position+ offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
