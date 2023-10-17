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

    public PlayerInputs playerInputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        
        playerInputActions = new PlayerInput();
        playerInputActions.Player.Enabled();
        playerInputActions.Player.Movement.performed += MovementXY;
    }

    private void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector2 MousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector2)MousePosition - new Vector2(transform.position.x, transform.position.y);
    }

    private void MovementXY()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
