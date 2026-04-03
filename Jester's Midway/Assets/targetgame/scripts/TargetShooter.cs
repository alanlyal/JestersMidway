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

        // PLATFORM SWITCH FOR INPUT
#if UNITY_ANDROID || UNITY_IOS
        // On Mobile, we don't check for MouseButtonDown here 
        // because the UI Button handles the click via the Inspector!
#else
            // On PC/Editor, we check for the Mouse Click
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