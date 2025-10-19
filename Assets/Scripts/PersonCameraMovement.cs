using UnityEngine;

public class PersonCameraMovement : MonoBehaviour
{
    [SerializeField] private float sesnsityX;
    [SerializeField] private float sesnsityY;

    [SerializeField] private Transform person;

    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sesnsityX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sesnsityY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        person.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
