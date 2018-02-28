using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private int health = 0;
    [SerializeField]
    private float speed = 0.2f;



    void Start()
    {

    }

    //¿El golpe lo mató? 
    //Si = true
    //No = False
    public bool GetAttack(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Attack()
    {
        return damage;
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
