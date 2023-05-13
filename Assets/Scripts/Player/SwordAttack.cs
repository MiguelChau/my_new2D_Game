using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public float attackRange = 0.2f;
    public int attackDamage;
    public Transform playerSideReference;
    public LayerMask enemyLayers;

    private void Awake()
    {
        playerSideReference = GameObject.FindAnyObjectByType<Player>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();
        
        if(enemy != null)
        {
            enemy.Damage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
