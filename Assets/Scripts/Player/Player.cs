using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;

    [Header("Jump Collision Check")]
    public Collider2D mycollider2D;
    public float distanceToGround;
    public float spaceToGround;

    private Animator _currentPlayer;
    private float _currentSpeed;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
        _currentPlayer = Instantiate(sOPlayerSetup.player, transform);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
    }

    private void Update()
    {
        HandleMoviment();
        HandleJump();
        IsGrounded();
    }

    private void HandleMoviment()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);
        }   
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, false);
        }

        if(myRigidBody.velocity.x >0)
        {
            myRigidBody.velocity += sOPlayerSetup.friction;
        }
        else if (myRigidBody.velocity.x <0)
        {
            myRigidBody.velocity -= sOPlayerSetup.friction;
        }

        if (Input.GetKey(KeyCode.Z))
            _currentSpeed = sOPlayerSetup.speedRun;
        else
            _currentSpeed = sOPlayerSetup.speed;
    }

    private void HandleJump()
    {
        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            myRigidBody.velocity = Vector2.up * sOPlayerSetup.jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.blue, distanceToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + spaceToGround);
    }
}
