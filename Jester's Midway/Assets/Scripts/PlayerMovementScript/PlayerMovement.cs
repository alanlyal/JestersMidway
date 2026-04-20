using UnityEngine;
using UnityEngine.InputSystem;

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
#if UNITY_ANDROID
        if (mobileUI != null) mobileUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
#else
        if (mobileUI != null) mobileUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
#endif
    }
    void Update()
    {
        HandleInput();
        HandleRotation();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        bool jumpKeyPressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        if ((jumpKeyPressed || mobileJumpPressed) && isGrounded)
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
            float h = 0, v = 0;
#if !UNITY_ANDROID
    if (Keyboard.current != null)
    {
        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;
        if (Keyboard.current.aKey.isPressed) h = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;
    }
#endif
            x = (h != 0) ? h : moveJoystickInput.x;
            z = (v != 0) ? v : moveJoystickInput.y;
        }
    
    void HandleRotation()
    {
        float mouseX = 0, mouseY = 0;
#if UNITY_ANDROID
        mouseX = lookJoystickInput.x * mouseSensitivity * Time.deltaTime;
        mouseY = lookJoystickInput.y * mouseSensitivity * Time.deltaTime;
#else
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            mouseX = mouseDelta.x * (mouseSensitivity / 10f) * Time.deltaTime;
            mouseY = mouseDelta.y * (mouseSensitivity / 10f) * Time.deltaTime;
        }
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