using UnityEngine;

public class WaterGun : MonoBehaviour
{
    public GameObject waterPrefab;
    public float fireRate = 20f; // how many water particles per second.
    public float fireSpeed = 20f; // how fastr to shoot each particle.
    public float spread = 0.2f; // how much spread the "bullets" have.

    private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (waterPrefab != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InvokeRepeating(nameof(Spray), 0f, 1 / fireRate);
            }
            if (Input.GetMouseButtonUp(0))
            {
                CancelInvoke(nameof(Spray));
            }
        }
    }

    public void Spray()
    {
        GameObject water = Instantiate(waterPrefab, this.transform.position, this.transform.localRotation);
        rb = water.GetComponent<Rigidbody>();

        Vector3 direction = this.transform.forward + new Vector3(
            Random.Range(-spread, spread),
            Random.Range(-spread, spread),
            Random.Range(-spread, spread)
        );

        direction.Normalize();

        rb.AddForce(direction * fireSpeed);
    }
}
