using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;

    private Vector3 direction;
    private bool isMoving = true;
    float speed = 5f;
    float timeToIncreaseSpeed = 5f;
    float elapsedTime = 0f;
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.Player.OnJump.performed += OnJump_performed;
        playerInputActions.Player.OnMoveLeft.performed += OnMoveLeft_performed;
        playerInputActions.Player.OnMoveRight.performed += OnMoveRight_performed;


    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeToIncreaseSpeed)
        {
            speed += 1f;
            elapsedTime = 0f;
        }
        if (isMoving)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        //if (isMoving)
        //{
        //    transform.position += Vector3.forward * Time.deltaTime;

        //}
        //transform.position += direction*Time.deltaTime;
    }
    private void OnMoveRight_performed(InputAction.CallbackContext obj)
    {
        //direction = Vector3.right * 5f;
        if (transform.position.x <= 4)
        {
            transform.position += Vector3.right * 5f;
        }
    }

    private void OnMoveLeft_performed(InputAction.CallbackContext obj)
    {
        //direction = Vector3.left * 5f;
        if (transform.position.x >= -4)
        {
            transform.position += Vector3.left * 5f;
        }
    }

    private void OnJump_performed(InputAction.CallbackContext obj)
    {
        if (transform.position.y<1)
        {
            playerRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

       
    }
}
