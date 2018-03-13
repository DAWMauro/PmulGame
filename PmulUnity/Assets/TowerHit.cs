using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHit : MonoBehaviour {

    //private Stats estadisticasPropia;
    private Stats estadisticasRival;

    void Start () {
        //estadisticasPropia = GetComponent<Stats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ally"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }

}
