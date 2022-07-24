using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour
{

    private Animator animator;
    private PlayerMover Mover;
    void Start()
    {
        animator = GetComponent<Animator>();
        Mover = GetComponent<PlayerMover>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }

        animator.SetBool("Walk", Mover.IsWalk);


    }
}
