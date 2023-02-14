using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    public event EventHandler OnPauseAction;
    public event EventHandler OnBindingRebind;

    private const string PLAYER_PREFS_BINDINGS = "InputBindings";

    public enum Binding
    {

        Move_Left,
        Move_Right,
        Confirm,
        Jump,
        Pause

    }
    public static GameInput Instance { get; private set; }
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
        {
            playerInputActions.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
        }

        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed; 
        playerInputActions.Player.Pause.performed += Pause_performed;
        

    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Interact.performed-= Interact_performed; 
        playerInputActions.Player.Pause.performed -= Pause_performed;
        playerInputActions.Dispose();
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    //public Vector2 GetMovementVectorNormalized()
    //{
    //    Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
    //    inputVector = inputVector.normalized;
    //    return inputVector;
    //}
    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {

            default:
            case Binding.Move_Left:
                return playerInputActions.Player.OnMoveLeft.bindings[0].ToDisplayString();
            case Binding.Move_Right:
                return playerInputActions.Player.OnMoveRight.bindings[0].ToDisplayString();
            case Binding.Confirm:
                return playerInputActions.Player.Interact.bindings[0].ToDisplayString();
            case Binding.Jump:
                return playerInputActions.Player.OnJump.bindings[0].ToDisplayString();
            case Binding.Pause:
                return playerInputActions.Player.Pause.bindings[0].ToDisplayString();


        }

    }
    public void RebindBinding(Binding binding, Action onActionRebound)
    {
        playerInputActions.Player.Disable();
        InputAction inputAction;
        int bindingIndex;
        switch (binding)
        {
            default:

            case Binding.Move_Left:
                inputAction = playerInputActions.Player.OnMoveLeft;
                bindingIndex = 3;
                break;
            case Binding.Move_Right:
                inputAction = playerInputActions.Player.OnMoveRight;
                bindingIndex = 4;
                break;
            case Binding.Confirm:
                inputAction = playerInputActions.Player.Interact;
                bindingIndex = 0;
                break;
            case Binding.Jump:
                inputAction = playerInputActions.Player.OnJump;
                bindingIndex = 0;
                break;
            case Binding.Pause:
                inputAction = playerInputActions.Player.Pause;
                bindingIndex = 0;
                break;


        }
        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback =>
            {
                callback.Dispose();
                playerInputActions.Enable();
                onActionRebound();
                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, playerInputActions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();
                OnBindingRebind?.Invoke(this, EventArgs.Empty);
            }).Start();

    }
}
