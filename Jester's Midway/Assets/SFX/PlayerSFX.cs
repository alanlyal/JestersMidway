using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f;

    private AudioSource audioSource;
    private float stepTimer;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFootsteps();
    }

    void HandleFootsteps()
    {
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f; // Reset timer when not moving
            audioSource.Stop(); // Stop any playing footstep sound when the player stops moving
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length == 0) return;

        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        audioSource.clip = clip;
        audioSource.volume = 1f;
        audioSource.Play();
    }
}
