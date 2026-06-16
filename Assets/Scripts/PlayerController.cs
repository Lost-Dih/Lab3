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
        ConstraintPlayerPosition(); //Calls function to constrain player position within boundaries
    }

    void ConstraintPlayerPosition()
    {
        if(transform.position.z < -zBoundary) //Checks if player has moved beyond the negative z boundary
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundary);
        }
         else if(transform.position.z > zBoundary) //Checks if player has moved beyond the positive z boundary
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary);
        }
    }

    void MovePlayer()
    {
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput); //Creates a movement direction vector based on the player's input
        playerRigidbody.AddForce(moveDirection * speed); //Applies a force to the player's Rigidbody in the direction of movement, scaled by the speed variable
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
}
