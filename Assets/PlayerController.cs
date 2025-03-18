using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpHeight = 3.0f;
    public float mouseSensitivity = 5.0f;

    private float rotationX = 0;
    private Rigidbody rb;
    private Camera playerCamera;
    private Vector3 targetVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = targetVelocity;
    }

    void HandleMouseLook()
    {

        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
    }

    void HandleMovement()
    {

        float moveDirectionX = Input.GetAxis("Horizontal") * speed;
        float moveDirectionZ = Input.GetAxis("Vertical") * speed;

        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;

        targetVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        if (Input.GetButtonDown("Jump") && rb.linearVelocity.y > -0.01f && rb.linearVelocity.y < 0.01f)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}