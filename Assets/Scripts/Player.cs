using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;
    private PlayerAnimator playerAnimator;
    public SpawnManager spawnManager;
    private PlayerInputActions playerInputActions;
    public static Player Instance;


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
        Instance = this;
        itemLayer = LayerMask.GetMask("Barrier");
        itemLayer1 = LayerMask.GetMask("Coin");
    }
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.Player.OnJump.performed += OnJump_performed;
        playerInputActions.Player.OnMoveLeft.performed += OnMoveLeft_performed;
        playerInputActions.Player.OnMoveRight.performed += OnMoveRight_performed;
        playerInputActions.Player.OnJump.canceled += OnJump_canceled;
        playerInputActions.Player.OnResizing.performed += OnResizing_performed;
        playerInputActions.Player.OnResizing.canceled += OnResizing_canceled;

    }
    private void OnDestroy()
    {
        playerInputActions.Player.OnJump.performed -= OnJump_performed;
        playerInputActions.Player.OnMoveLeft.performed -= OnMoveLeft_performed;
        playerInputActions.Player.OnMoveRight.performed -= OnMoveRight_performed;
        playerInputActions.Player.OnJump.canceled -= OnJump_canceled;
        playerInputActions.Player.OnResizing.performed -= OnResizing_performed;
        playerInputActions.Player.OnResizing.canceled -= OnResizing_canceled;
        playerInputActions.Dispose();
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
        if (other.tag == "SpawnTrigger")
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
            if (Physics.Raycast(transform.position, direction, out hit, .5f))
            {
                Debug.Log("ez1");

                for (int i = 0; i < hit.collider.transform.childCount; i++)
                {

                    Debug.Log("789");
                    Transform child = hit.collider.transform.GetChild(i);
                    if (child.gameObject.activeSelf)
                    {
                        if (child.CompareTag("CoinMagnet"))
                        {
                            Debug.Log("CoinMagnet found!");
                            DistanceCounter.Instance.ActivateDoublePoints();
                            //MysteryItem.Instance.ActivateCoinMagnet();
                            //hit.collider.gameObject.SetActive(false);

                        }
                        if (child.CompareTag("SpeedDown"))
                        {

                            Debug.Log(speed + " speed " + child);
                            speed += transform.position.z > 500 ? -1f : 1f;
                            Debug.Log(speed + " speed " + child);
                            hit.collider.gameObject.SetActive(false);

                        }
                    }
                }
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
        if (!SubwaySurfersGameManager.Instance.IsGameOver() && transform.position.x <= 4)
        {
            transform.position += Vector3.right * 5f;
        }
    }

    private void OnMoveLeft_performed(InputAction.CallbackContext obj)
    {
        //direction = Vector3.left * 5f;
        if (!SubwaySurfersGameManager.Instance.IsGameOver() && transform.position.x >= -4)
        {
            transform.position += Vector3.left * 5f;
        }
    }

    private void OnJump_performed(InputAction.CallbackContext obj)
    {
        if (!SubwaySurfersGameManager.Instance.IsGameOver() && transform.position.y < 1)
        {
            playerRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            isJumping = true;

        }


    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public float GetSpeed()
    {
        return speed;

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
    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
}
