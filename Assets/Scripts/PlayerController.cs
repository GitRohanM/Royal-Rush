using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float xClamp = 5f;
    [SerializeField] float yClamp = 5f;
    [SerializeField] float controlSpeed = 10f;

    Rigidbody rb;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }


    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (movementSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -yClamp, yClamp);
        
        rb.MovePosition(newPosition);
    }
}
