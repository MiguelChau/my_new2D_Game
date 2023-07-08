using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Animator animator;
    public int damage;
    public string triggerAttack = "Attack";
    public string triggerDie = "Die";


    public HealthBase healthBase;
    public float timeToDestroy;
    public AudioSource audioSourceKill;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }

        transform.Scale(1.3f);
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDieAnimation();
        if (audioSourceKill != null) audioSourceKill.Play();
        Destroy(gameObject, timeToDestroy);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
           Debug.Log(collision.transform.name);

           var health = collision.gameObject.GetComponent<HealthBase>();

            if (health != null)
            {
                health.Damage(damage);
                PlayAttackAnimation();
            }
        

    }
    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDieAnimation()
    {
        animator.SetTrigger(triggerDie);
    }

  
}
