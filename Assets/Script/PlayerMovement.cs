using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;
    public Rigidbody2D rb;
    public int speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void Update()
    {
        LookAtMouse();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void LookAtMouse()
    {
        Vector2 MousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector2)MousePosition - new Vector2(transform.position.x, transform.position.y);
    }

}
