using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;
    private const string IS_JUMPING = "IsJumping";
    private const string IS_PLAYING = "IsPlaying";
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        Debug.Log(SubwaySurfersGameManager.Instance.IsGamePlaying());

        animator.SetBool(IS_PLAYING, SubwaySurfersGameManager.Instance.IsGamePlaying());
        animator.SetBool(IS_JUMPING, player.IsJumping());
    }
    public void IsGrounded()
    { 
        if (player.transform.position.y==0) 
        {
        
        }
    }

}
