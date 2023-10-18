using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput;
    
    public Vector2 movement;
    public Rigidbody2D rb;
    public int speed;

    public ActionController playerInputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new ActionController();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed += MovementXY;
    }

    private void FixedUpdate()
    {
        movement = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        LookAtMouse();
    }
    private void MovementXY(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void LookAtMouse()
    {
        Vector2 MousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector2)MousePosition - new Vector2(transform.position.x, transform.position.y);
    }


}
