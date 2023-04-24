using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;
    
    [SerializeField] private Player1 player1;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
     private void update() {
        animator.SetBool(IS_WALKING, player1.IsWalking());
    }
}
