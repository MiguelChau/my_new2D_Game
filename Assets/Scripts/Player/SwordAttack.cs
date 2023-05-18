using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public float attackRange = 0.2f;
    public int attackDamage;
    public Transform playerSideReference;
    public LayerMask enemyLayers;
    public AudioSource audioSourceHit;

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
        if (audioSourceHit != null) audioSourceHit.Play();
        PlayHitVFX();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void PlayHitVFX()
    {
        VFXManager.Instance.PlayByTypeVFX(VFXManager.VFXType.HIT, transform.position);
    }
}
