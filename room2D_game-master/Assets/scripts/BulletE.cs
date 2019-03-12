using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletE : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 1;
    // public GameObject inpactEffect;//efekt uderzenia bulletu

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
      
        if (hitInfo.tag!="Enemy")
        {
        Hero hero = hitInfo.GetComponent<Hero>();//wykryj czy bullet uderzyl jakis obiekt o klasie hero
        if (hero != null)//jezeli tak to zadaj dmg
        {
            hero.TakeDamage(damage);
            // Instantiate(inpactEffect, transform.position, transform.rotation);//stworz animacje uderzenia
            Destroy(gameObject);
        }
        }
        else if(hitInfo.name=="tlo")
            Destroy(gameObject,1);


    }
}
