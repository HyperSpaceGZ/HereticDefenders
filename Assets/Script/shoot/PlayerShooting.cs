using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public PlayerInput playerInput;

    public Transform spawnposition;
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
        GameObject bulletClone = ObjectPooling.SharedInstance.GetPooledObject(1);
        
        if (bulletClone != null )
        {
            bulletClone.transform.position = spawnposition.position;
            bulletClone.transform.rotation = spawnposition.rotation;

            bulletClone.SetActive(true);

            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(Vector3.up * force, ForceMode2D.Impulse);

        }
        
    }
}
