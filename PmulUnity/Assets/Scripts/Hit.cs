using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    private Animator animator;

    private Vector3 direction;

    private Stats estadisticasPropia;
    private Stats estadisticasRival;

    private EnemyHit enemy;

    private bool movement = true;

    private bool dead = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("InCombat", true);
        estadisticasPropia = GetComponent<Stats>();
        
        direction = new Vector3(estadisticasPropia.Speed, 0, 0);
        if (estadisticasPropia.Speed >= 1)
        {
            animator.Play("Run");
        }

    }

    private void Update()
    {
        if (movement)
        {
            transform.position += direction * Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            movement = false;
            animator.speed = 2;
            animator.Play("Attack");
            estadisticasRival = collision.gameObject.GetComponent<Stats>();
            enemy = collision.gameObject.GetComponent<EnemyHit>();
        }
    }

    public void IsDead()
    {
        animator.SetBool("InCombat", false);
        animator.Play("Die");
        dead = true;
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (!dead)
            {
                movement = true;
                animator.Play("Run");
                animator.speed = 1;
            }
        }
    }
    private void HitEvent()
    {
        if (estadisticasRival.GetAttack(estadisticasPropia.Attack()))
        {
            enemy.IsDead();
        }
    }

}
