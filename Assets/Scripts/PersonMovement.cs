using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        MovementInput();
    }

    void FixedUpdate()
    {
        PersoneMove();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void PersoneMove()
    {
        movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        rigidbody.AddForce(movementDirection * moveSpeed, ForceMode.Force);
    }
}
