using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] Animator jumpAnimator;
    // const string jumpString = "Jump";
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float xClamp = 5f;
    [SerializeField] float yClamp = 5f;
    // [SerializeField] float jumpDuration = 0.6f;
    // [SerializeField] float jumpDistance = 3f;

    // private bool isJumping = false;

    Rigidbody rb;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        // {
        //     jumpAnimator.SetTrigger(jumpString);
        //     StartCoroutine(JumpWithForwardMotion());
        // }
        HandleEscape();
    }
    void FixedUpdate()
    {
        HandleMovement();
    }

    // IEnumerator JumpWithForwardMotion()
    // {
    //     isJumping = true;
    //     float elapsed = 0f;
    //     Vector3 startPos = transform.position;
    //     Vector3 endPos = startPos + transform.forward * jumpDistance;

    //     while (elapsed < jumpDuration) {
    //         transform.position = Vector3.Lerp(startPos, endPos, elapsed / jumpDuration);
    //         elapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     transform.position = endPos;
    //     isJumping = false;
    // }
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

    void HandleEscape()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    public void HandleMovementSpeed()
    {
        if (movementSpeed >= 15f)
        {
            movementSpeed = 15f;
            return;
        }
        else
        {
            movementSpeed += .2f;
        }
    }
}
