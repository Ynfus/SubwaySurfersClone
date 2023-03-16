using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;
    private const string IS_JUMPING = "IsJumping";
    private const string IS_PLAYING = "IsPlaying";
    private const string IS_RESIZING = "IsResizing";
    private const string IS_GAMEOVER = "IsGameOver";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        animator.SetBool(IS_PLAYING, SubwaySurfersGameManager.Instance.IsGamePlaying());
        animator.SetBool(IS_JUMPING, player.IsJumping());
        animator.SetBool(IS_RESIZING, player.IsResizing());
        animator.SetBool(IS_GAMEOVER, SubwaySurfersGameManager.Instance.IsGameOver());
    }
    public void SetIsJumpingFalse()
    {
        Player.Instance.SetIsJumpingFalse();
    }
    public void SetIsAnimationJumpingFalse()
    {
        Player.Instance.SetIsAnimationJumpingFalse();
    }
    public void DebugSmth()
    { Player.Instance.ResizeCapsuleCollider(); }
    public void ResizeBack()
    {
        Player.Instance.ResizeCapsuleCollider1();

    }

}
