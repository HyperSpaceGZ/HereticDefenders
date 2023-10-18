using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public PlayerInput playerInput;

    public Transform spawnposition;
    public GameObject bulletprefab;
    public float force;
    public float lifetime  = 2f;

    public ActionController playerInputActions;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new ActionController();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Shooting.performed += OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        GameObject bulletclone = Instantiate(bulletprefab, spawnposition.position, spawnposition.rotation);
        Rigidbody2D rb = bulletclone.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector3.up * force, ForceMode2D.Impulse);
        Destroy(bulletclone, lifetime);
    }
}
