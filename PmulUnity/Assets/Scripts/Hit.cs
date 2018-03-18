using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    private bool aliado;
    private string compañero;
    private string enemigo;

    private Interface gameInterface;
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

    //¿Puede atacar a la torre?
    private bool attackTower = false;


    void Start()
    {
        gameInterface = GameObject.Find("GameManager").GetComponent<Interface>();
        //
        if (aliado)
        {
            compañero = "Ally";
            enemigo = "Enemy";
        }
        else
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
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.tag.Equals(enemigo))
        {
            if (!combat)
            {
                movement = false;
                combat = true;
                animator.Play("Attack");
                estadisticasRival = collisionObject.GetComponent<Stats>();
                enemy = collisionObject.GetComponent<Hit>();
            }
        }
        else if (collisionObject.tag.Equals(compañero))
        {
            if (!combat)
            {
                if (aliado) {
                    if (collision.transform.position.x > transform.position.x)
                    {                        
                        movement = false;
                        animator.Play("Idle");
                    }
                }
                else
                {
                    if (collision.transform.position.x < transform.position.x)
                    {
                        movement = false;
                        animator.Play("Idle");
                    }
                }
                
            }
        }
        else if (collision.gameObject.tag.Equals("Tower") && attackTower)
        {
            movement = false;
            combat = true;
            animator.Play("Attack");
            estadisticasRival = collisionObject.GetComponent<Stats>();
            //enemy = collision.gameObject.GetComponent<Hit>();
        }
    }

    public void IsDead()
    {
        dead = true;
        animator.SetBool("InCombat", false);
        animator.Play("Die");
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
                combat = false;
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
            if (aliado)
                gameInterface.Gold += estadisticasRival.Reward;
        }
    }

}
