using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;

    [Header("Jump Collision Check")]
    public Collider2D mycollider2D;
    public float distanceToGround;
    public float spaceToGround;

    private float _currentSpeed;

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
        }   
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
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
