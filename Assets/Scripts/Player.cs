using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;
    private PlayerAnimator playerAnimator;
    public SpawnManager spawnManager;

    private bool isMoving = true;
    float speed = 5f;
    float timeToIncreaseSpeed = 1f;
    float elapsedTime = 0f;
    bool isJumping = false;
    private bool isCollision = false;
    private bool isResizing = false;
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
        playerInputActions.Player.OnResizing.performed += OnResizing_performed;
        playerInputActions.Player.OnResizing.canceled += OnResizing_canceled;

    }

    private void OnResizing_canceled(InputAction.CallbackContext obj)
    {
        isResizing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            Debug.Log("eee");
        }
        if (other.tag=="SpawnTrigger")
        {
                spawnManager.SpawnTriggerEntered(); 
        }
    }



    private void Update()
    {
        if (SubwaySurfersGameManager.Instance.IsGamePlaying())
        {
            Vector3 direction = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, direction, 2f, itemLayer))
            {
                Debug.Log("Wykryto przedmiot: ");
                isCollision = true;
            }
            else
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= timeToIncreaseSpeed)
                {
                    speed += .1f;
                    elapsedTime = 0f;
                }
                if (isMoving)
                {
                    transform.position += Vector3.forward * speed * Time.deltaTime;
                }
            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, .5f, itemLayer1))
            {
                Debug.Log("Wykryto przedmiot: asdasdasdasdasdasdasdasdasdasddasdd");
                SoundManager.Instance.PlayCoinSound();
                CoinsCounter.Instance.IncreaseCoinsAmount();
                hit.collider.gameObject.SetActive(false);
            }
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

    private void OnJump_canceled(InputAction.CallbackContext obj)
    {
        isJumping = false;
    }

    private void OnResizing_performed(InputAction.CallbackContext obj)
    {
        isResizing = true;
    }
    public bool IsCollision()
    {
        return isCollision;
    }
    public bool IsJumping()
    {
        return isJumping;

    }
    public bool IsResizing()
    {
        return isResizing;
    }
}
