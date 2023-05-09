using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 0.2f;
    public int attackDamage;
    public Transform playerSideReference;

    private void Awake()
    {
        playerSideReference = GameObject.FindAnyObjectByType<Player>().transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();
        if(enemy != null)
        {
            enemy.Damage(attackDamage);
        }
    }
}
