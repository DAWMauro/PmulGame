using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{    
    [SerializeField]
    private bool aliado;
    private string compañero;
    private string enemigo;

    private Animator animator;

    private Vector3 direction;

    private Stats estadisticasPropia;
    private Stats estadisticasRival;

    
    private Hit enemy;

    //¿Está en movimiento?
    private bool movement = true;

    //¿Está muerto?
    private bool dead = false;

    //¿Está en combate?
    private bool combat = false;

    private bool attackTower = false;


    void Start()
    {
        //
        if (aliado)
        {
            compañero = "Ally";
            enemigo = "Enemy";
        } else
        {
            compañero = "Enemy";
            enemigo = "Ally";
            attackTower = true;
        }
        //
        animator = GetComponent<Animator>();
        animator.SetBool("InCombat", true);
        estadisticasPropia = GetComponent<Stats>();
        //
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
        if (collision.gameObject.tag.Equals(enemigo))
        {
            movement = false;
            combat = true;
            animator.Play("Attack");
            estadisticasRival = collision.gameObject.GetComponent<Stats>();
            enemy = collision.gameObject.GetComponent<Hit>();
        }
        else if (collision.gameObject.tag.Equals(compañero))
        {
            if (!combat)
            {
                movement = false;
                animator.Play("Idle");
            }
        } else if (collision.gameObject.tag.Equals("Tower") && attackTower)
        {
            movement = false;
            combat = true;
            animator.Play("Attack");
            estadisticasRival = collision.gameObject.GetComponent<Stats>();
            //enemy = collision.gameObject.GetComponent<Hit>();
        }
    }

    public void IsDead()
    {
        animator.SetBool("InCombat", false);
        animator.Play("Die");
        dead = true;
        GetComponent<Renderer>().sortingOrder = 0;
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(enemigo))
        {
            if (!dead)
            {
                movement = true;
                if (estadisticasPropia.Speed >= 1)
                {
                    animator.Play("Run");
                }
                else
                {
                    animator.Play("Walk");
                }
            }
        }
        else if (collision.gameObject.tag.Equals(compañero))
        {
            if (!dead)
            {
                movement = true;
                if (estadisticasPropia.Speed >= 1)
                {
                    animator.Play("Run");
                }
                else
                {
                    animator.Play("Walk");
                }
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
