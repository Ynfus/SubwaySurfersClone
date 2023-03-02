using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class MainMenuAnimator : MonoBehaviour
{
    [SerializeField] private GameObject[] player;
    private Animator animator;

    private void Start()
    {
        int randomDance = Random.Range(0, 10);
        foreach (GameObject p in player)
        {
            Animator animator = p.GetComponent<Animator>();
            animator.SetInteger("Random", randomDance);
        }
    }
}
