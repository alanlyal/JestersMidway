using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    bool canShoot = false;

    void Start()
    {
        Invoke(nameof(EnableShooting), 0.2f);
    }

    void EnableShooting()
    {
        canShoot = true;
    }

    void Update()
    {
        if (!canShoot) return;

        
#if UNITY_ANDROID || UNITY_IOS
       
#else
            
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
#endif
    }


    public void Shoot()
    {
        if (!canShoot) return;
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