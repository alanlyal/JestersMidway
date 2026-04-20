using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f;

    private AudioSource audioSource;
    private float stepTimer;
    private Rigidbody rb; 

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        HandleFootsteps();
    }

    void HandleFootsteps()
    {
        bool isMoving = false;
        if (rb != null && rb.linearVelocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        if (!isMoving && Keyboard.current != null)
        {
            isMoving = Keyboard.current.wKey.isPressed || Keyboard.current.aKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.dKey.isPressed;
        }
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
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length == 0 || audioSource == null) return;
        audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
    }
}