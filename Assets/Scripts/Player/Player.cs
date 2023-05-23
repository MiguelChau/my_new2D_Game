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
    public bool _isAttacking;

    // public ParticleSystem jumpVFX;
    public AudioPlayAudioClips randomJump;

    public float timeToChangeScreen = .2f;
    public GameOver gameOver;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
        _currentPlayer = Instantiate(sOPlayerSetup.player, transform);

        if(mycollider2D != null)
        {
            distanceToGround = mycollider2D.bounds.extents.y;
        }
    }

    private void OnPlayerKill()
    {
        
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(sOPlayerSetup.triggerDeath);


        if (mycollider2D != null)
        {
            mycollider2D.enabled = false;
        }

        StartCoroutine(TimeChangeScreen());
    }

    private void Update()
    {
        HandleMoviment();
        HandleJump();
        IsGrounded();
        Attack();
    }

    private void HandleMoviment()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }
            PlayRunVFX();
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);

        }   
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }
            PlayRunVFX();
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

    private void PlayRunVFX()
    {
        VFXManager.Instance.PlayByTypeVFX(VFXManager.VFXType.RUN, transform.position);
    }

    private void HandleJump()
    {
        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            myRigidBody.velocity = Vector2.up * sOPlayerSetup.jumpForce;
            PlayJumpVFX();
            _currentPlayer.SetBool(sOPlayerSetup.boolJump, true);
            if (randomJump != null) randomJump.PlayClips(); 
    
        }
        else
        {
            _currentPlayer.SetBool(sOPlayerSetup.boolJump, false);
        }



    }

    private void PlayJumpVFX()
    {
        //if (jumpVFX != null) jumpVFX.Play();
        VFXManager.Instance.PlayByTypeVFX(VFXManager.VFXType.JUMP, transform.position);
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.blue, distanceToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + spaceToGround);
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isAttacking = true;
            _currentPlayer.SetTrigger("AttackTrigger");
        }
        else
        {
            _isAttacking = false;
        }
    }

    public void TakeDamage(int damage)
    {
        healthBase.Damage(damage);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    IEnumerator TimeChangeScreen()
    {
        yield return new WaitForSeconds(timeToChangeScreen);
        gameOver.ShowGameOverScreen();
        gameObject.SetActive(false);
        
    }
}
