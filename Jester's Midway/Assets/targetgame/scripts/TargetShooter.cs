using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    bool canShoot = false;

    void Start()
    {
        Invoke(nameof(EnableShooting), 0.2f); // small delay
    }

    void EnableShooting()
    {
        canShoot = true;
    }

    void Update()
    {
        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.GetComponent<Target>();

                if (target != null)
                {
                    target.Hit();
                }
            }
        }
    }
}
