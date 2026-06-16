using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public InputAction moveAction;
    private Rigidbody playerRigidbody;
    private Vector2 moveInput;
    private float zBoundary = 12.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if(transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundary);
        }
         else if(transform.position.z > zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary);
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        playerRigidbody.AddForce(moveDirection * speed);
    }
}
