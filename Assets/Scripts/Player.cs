using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;
    private PlayerAnimator playerAnimator;

    private bool isMoving = true;
    float speed = 5f;
    float timeToIncreaseSpeed = 1f;
    float elapsedTime = 0f;
    bool isJumping = false;
    bool isCollision = false;
    private LayerMask itemLayer;
    private LayerMask itemLayer1;
    private void Start()
    {
        itemLayer = LayerMask.GetMask("Barrier");
        itemLayer1 = LayerMask.GetMask("Coin");
    }
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.Player.OnJump.performed += OnJump_performed;
        playerInputActions.Player.OnMoveLeft.performed += OnMoveLeft_performed;
        playerInputActions.Player.OnMoveRight.performed += OnMoveRight_performed;
        playerInputActions.Player.OnJump.canceled += OnJump_canceled;


    }

    private void OnJump_canceled(InputAction.CallbackContext obj)
    {
        isJumping = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            Debug.Log("eee");
        }
    }



    private void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, direction, .35f, itemLayer))
        {
            Debug.Log("Wykryto przedmiot: ");
            transform.position = Vector3.zero;

        }
        else
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
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction,out hit, 5f, itemLayer1))
        {
            Debug.Log("Wykryto przedmiot: asdasdasdasdasdasdasdasdasdasddasdd");
            CoinsCounter.Instance.IncreaseCoinsAmount();
            hit.collider.gameObject.SetActive(false);
        }
        //if (playerRigidbody.position.y < 0.2)
        //{
        //    isJumping = false;
        //}

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
        if (transform.position.y < 1)
        {
            playerRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            isJumping = true;

        }


    }
    public bool IsJumping()
    {
        return isJumping;

    }
}
