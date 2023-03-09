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
    bool isAnimationJumping = false;
    private bool isCollision = false;
    private bool isResizing = false;
    private LayerMask itemLayer;
    private LayerMask itemLayer1;
    private LayerMask itemLayerMaskBarrier;
    private LayerMask itemLayerMaskCoin;
    private LayerMask itemLayerMaskMysteryItem;
    private float distanceToInteract = .5f;
    RaycastHit hit;
    private void Start()
    {
        Instance = this;
        itemLayerMaskBarrier = LayerMask.GetMask("Barrier");
        itemLayerMaskCoin = LayerMask.GetMask("Coin");
        itemLayerMaskMysteryItem = LayerMask.GetMask("MysteryItem");
        itemLayer = LayerMask.GetMask("Barrier");
        itemLayer1 = LayerMask.GetMask("Coin");
    }
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
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
        playerInputActions.Player.OnResizing.performed += OnResizing_performed;
        playerInputActions.Player.OnResizing.canceled += OnResizing_canceled;

    }
    private void OnDestroy()
    {
        playerInputActions.Player.OnJump.performed -= OnJump_performed;
        playerInputActions.Player.OnMoveLeft.performed -= OnMoveLeft_performed;
        playerInputActions.Player.OnMoveRight.performed -= OnMoveRight_performed;
        playerInputActions.Player.OnResizing.performed -= OnResizing_performed;
        playerInputActions.Player.OnResizing.canceled -= OnResizing_canceled;
        playerInputActions.Dispose();
    }

    private void OnResizing_canceled(InputAction.CallbackContext obj)
    {
        isResizing = false;
    }




    private void Update()
    {
        if (SubwaySurfersGameManager.Instance.IsGamePlaying())
        {


            Vector3 direction = transform.forward;
            bool isHit = Physics.Raycast(transform.position, direction, out hit, distanceToInteract);

            if (isHit)
            {
                int hitLayer = hit.collider.gameObject.layer;
                LayerMask itemLayerMaskCoin = LayerMask.GetMask("Coin");

                if (hitLayer == LayerMask.NameToLayer("Barrier"))
                {
                    isCollision = true;
                    SoundManager.Instance.PlayDeathSound();
                }

                if (hitLayer == LayerMask.NameToLayer("Coin"))
                {
                    SoundManager.Instance.PlayCoinSound();
                    CoinsCounter.Instance.IncreaseCoinsAmount();
                    hit.collider.gameObject.SetActive(false);
                }

                if (hitLayer == LayerMask.NameToLayer("MysteryItem"))
                {
                    for (int i = 0; i < hit.collider.transform.childCount; i++)
                    {


                        Transform child = hit.collider.transform.GetChild(i);
                        if (child.gameObject.activeSelf)
                        {
                            switch (child.tag)
                            {
                                case "CoinMagnet":
                                    MysteryItem.Instance.ActivateCoinMagnet();
                                    hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                                    break;
                                case "DoublePoints":
                                    DistanceCounter.Instance.ActivateDoublePoints();
                                    hit.collider.gameObject.SetActive(false);
                                    break;
                                case "SpeedDown":
                                    speed += transform.position.z > 500 ? -1f : 1f;
                                    hit.collider.gameObject.SetActive(false);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                }
            }

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToIncreaseSpeed)
            {
                speed += .1f;
                elapsedTime = 0f;
            }
            if (isMoving)
            {
                transform.position += direction * speed * Time.deltaTime;
            }










            //Vector3 direction = transform.TransformDirection(Vector3.forward);
            //if (Physics.Raycast(transform.position, direction, 2f, itemLayer))
            //{
            //    isCollision = true;
            //    SoundManager.Instance.PlayDeathSound();

            //}
            //else
            //{
            //    elapsedTime += Time.deltaTime;
            //    if (elapsedTime >= timeToIncreaseSpeed)
            //    {
            //        speed += .1f;
            //        elapsedTime = 0f;
            //    }
            //    if (isMoving)
            //    {
            //        transform.position += Vector3.forward * speed * Time.deltaTime;
            //    }
            //}
            //RaycastHit hit;
            //if (Physics.Raycast(transform.position, direction, out hit, .5f, itemLayer1))
            //{
            //    SoundManager.Instance.PlayCoinSound();
            //    CoinsCounter.Instance.IncreaseCoinsAmount();
            //    hit.collider.gameObject.SetActive(false);
            //}
            //if (Physics.Raycast(transform.position, direction, out hit, .5f))
            //{
            //    for (int i = 0; i < hit.collider.transform.childCount; i++)
            //    {


            //        Transform child = hit.collider.transform.GetChild(i);
            //        if (child.gameObject.activeSelf)
            //        {
            //            if (child.CompareTag("CoinMagnet"))
            //            {
            //                MysteryItem.Instance.ActivateCoinMagnet();
            //                hit.collider.transform.GetChild(0).gameObject.SetActive(false);

            //            }
            //            if (child.CompareTag("DoublePoints"))
            //            {
            //                DistanceCounter.Instance.ActivateDoublePoints();
            //                hit.collider.gameObject.SetActive(false);


            //            }
            //            if (child.CompareTag("SpeedDown"))
            //            {

            //                speed += transform.position.z > 500 ? -1f : 1f;
            //                hit.collider.gameObject.SetActive(false);

            //            }
            //        }
            //    }
            //}









            //    Vector3 direction = transform.TransformDirection(Vector3.forward);
            //    if (Physics.Raycast(transform.position, direction, 2f, itemLayerMaskBarrier))
            //    {
            //        isCollision = true;
            //        SoundManager.Instance.PlayDeathSound();

            //    }
            //    else
            //    {
            //        elapsedTime += Time.deltaTime;
            //        if (elapsedTime >= timeToIncreaseSpeed)
            //        {
            //            speed += .1f;
            //            elapsedTime = 0f;
            //        }
            //        if (isMoving)
            //        {
            //            transform.position += Vector3.forward * speed * Time.deltaTime;
            //        }
            //    }
            //    RaycastHit hit;
            //    if (Physics.Raycast(transform.position, direction, out hit, .5f, itemLayerMaskCoin))
            //    {
            //        SoundManager.Instance.PlayCoinSound();
            //        CoinsCounter.Instance.IncreaseCoinsAmount();
            //        hit.collider.gameObject.SetActive(false);
            //    }
            //    if (Physics.Raycast(transform.position, direction, out hit, distanceToInteract, itemLayerMaskMysteryItem))
            //    {
            //        for (int i = 0; i < hit.collider.transform.childCount; i++)
            //        {
            //            Transform child = hit.collider.transform.GetChild(i);
            //            if (child.gameObject.activeSelf)
            //            {
            //                switch (child.tag)
            //                {
            //                    case "Coin":
            //                        SoundManager.Instance.PlayCoinSound();
            //                        CoinsCounter.Instance.IncreaseCoinsAmount();
            //                        hit.collider.gameObject.SetActive(false);
            //                        break;
            //                    case "CoinMagnet":
            //                        MysteryItem.Instance.ActivateCoinMagnet();
            //                        hit.collider.transform.GetChild(0).gameObject.SetActive(false);
            //                        break;
            //                    case "DoublePoints":
            //                        DistanceCounter.Instance.ActivateDoublePoints();
            //                        hit.collider.gameObject.SetActive(false);
            //                        break;
            //                    case "SpeedDown":
            //                        speed += transform.position.z > 500 ? -1f : 1f;
            //                        hit.collider.gameObject.SetActive(false);
            //                        break;
            //                    default:
            //                        break;
            //                }
            //            }
            //        }
        }
        //}
    }
    private void OnMoveRight_performed(InputAction.CallbackContext obj)
    {
        if (!SubwaySurfersGameManager.Instance.IsGameOver() && transform.position.x <= 4)
        {
            transform.position += Vector3.right * 6f;
        }
    }

    private void OnMoveLeft_performed(InputAction.CallbackContext obj)
    {
        if (!SubwaySurfersGameManager.Instance.IsGameOver() && transform.position.x >= -4)
        {
            transform.position += Vector3.left * 6f;
        }
    }

    private void OnJump_performed(InputAction.CallbackContext obj)
    {
        if (!SubwaySurfersGameManager.Instance.IsGameOver() && /*transform.position.y < 1 &&*/ !isJumping && !isAnimationJumping)
        {
            playerRigidbody.AddForce(Vector3.up * 6f, ForceMode.Impulse);
            isJumping = true;
            isAnimationJumping = true;

        }


    }
    public void SetIsJumpingFalse()
    {
        isJumping = false;
    }
    public void SetIsAnimationJumpingFalse()
    {
        isAnimationJumping = false;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public float GetSpeed()
    {
        return speed;

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
