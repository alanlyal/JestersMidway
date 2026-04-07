using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Platform Settings")]
    public GameObject mobileUI; 

    [Header("Movement")]
    public float moveSpeed = 6f;
    public float airControl = 0.5f;

    [Header("Jump")]
    public float jumpForce = 6f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundMask;

    [Header("Mouse Look")]
    public Transform cameraTransform;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private Rigidbody rb;
    private float x, z;
    private bool isGrounded;

   
    [HideInInspector] public Vector2 moveJoystickInput;
    [HideInInspector] public Vector2 lookJoystickInput;
    [HideInInspector] public bool mobileJumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Toggle UI based on platform
#if UNITY_ANDROID
        if (mobileUI != null) mobileUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
#else
            if(mobileUI != null) mobileUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
#endif
    }

    void Update()
    {
        HandleInput();
        HandleRotation();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        if ((Input.GetKeyDown(KeyCode.Space) || mobileJumpPressed) && isGrounded)
        {
            Vector3 v = rb.linearVelocity;
            v.y = 0f;
            rb.linearVelocity = v;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            mobileJumpPressed = false; 
        }
    }

    void HandleInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        x = h != 0 ? h : moveJoystickInput.x;
        z = v != 0 ? v : moveJoystickInput.y;
    }

    void HandleRotation()
    {
        float mouseX, mouseY;

#if UNITY_ANDROID 
        mouseX = lookJoystickInput.x * mouseSensitivity * Time.deltaTime;
        mouseY = lookJoystickInput.y * mouseSensitivity * Time.deltaTime;
#else
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
#endif

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        Vector3 inputDir = transform.forward * z + transform.right * x;
        if (inputDir.magnitude > 1) inputDir.Normalize();

        Vector3 desired = inputDir * moveSpeed;
        float control = isGrounded ? 1f : airControl;

        Vector3 velocity = rb.linearVelocity;
        Vector3 targetVel = new Vector3(desired.x, velocity.y, desired.z);

        rb.linearVelocity = Vector3.Lerp(velocity, targetVel, control);
    }
    public void MobileJump() { mobileJumpPressed = true; }
}