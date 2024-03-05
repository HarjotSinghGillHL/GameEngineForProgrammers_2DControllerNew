using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HL_PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer LocalPlayerSprite;

    [SerializeField]
    private int moveSpeed = 250;

    private Vector2 vecVelocity = Vector2.zero;
    private Vector2 vecKeyboardMovement = Vector2.zero;
    private Vector2 vecLastKeyboardMovement = Vector2.zero;

    public bool bPlayerControllerActive = false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        LocalPlayerSprite = GetComponent<SpriteRenderer>();
        bPlayerControllerActive = true;
    }


    void PreMovementUpdate()
    {
        vecKeyboardMovement.x = Input.GetAxisRaw("Horizontal");
        vecKeyboardMovement.y = Input.GetAxisRaw("Vertical");
    }

    public void SetLocalPlayerState(bool bActive)
    {
        bPlayerControllerActive = bActive;
        LocalPlayerSprite.enabled = bActive;
    }
    void MovePlayer()
    {
        vecVelocity.x = (vecKeyboardMovement.x * Time.deltaTime);
        vecVelocity.y = (vecKeyboardMovement.y * Time.deltaTime);

        if (bPlayerControllerActive && vecKeyboardMovement != Vector2.zero)
        {
            animator.Play("Tree", 0);
            animator.SetFloat("X", vecVelocity.x);
            animator.SetFloat("Y", vecVelocity.y);
            vecLastKeyboardMovement = vecKeyboardMovement;
            vecVelocity *= moveSpeed;
            rigidBody.velocity = vecVelocity;
        }
        else
        {
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", 0);

            if (vecLastKeyboardMovement == Vector2.zero || vecLastKeyboardMovement.y == -1)
            {
                animator.Play("IdleDown", 0);
            }
            else if (vecLastKeyboardMovement.x == 1)
                    animator.Play("IdleRight", 0);
                else if (vecLastKeyboardMovement.x == -1)
                    animator.Play("IdleLeft", 0);
                else if (vecLastKeyboardMovement.y == 1)
                    animator.Play("IdleUp", 0);

            rigidBody.velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        PreMovementUpdate();
        MovePlayer();
    }
}
